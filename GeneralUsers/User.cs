using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace GeneralUsers {
// Абстрактный пользователь - прародитель всех классов иерархии.
// Содержит данные для авторизации и виртуальные методы авторизации,
// общие для гостя, сотрудника и абитуриента.
public abstract class User {
  public const int MinPasswordLength = 8;
  public const int CodeLength = 6;

  // Названия полей в файле пользователя.
  public const string KeyLogin = "Логин";
  public const string KeyPasswordHash = "Хеш пароля";
  public const string KeyAuthCode = "Код авторизации";

  private string login;
  private string passwordHash;
  private string authCode;

  public string Login {
    get => login;
    set {
      string text = (value ?? string.Empty).Trim();

      if (!IsValidLogin(text)) {
        throw new ArgumentException(
          "Логин должен содержать от 4 до 20 символов: латинские буквы, "
          + "цифры и знак подчёркивания, и начинаться с буквы."
        );
      }

      login = text;
    }
  }

  // Пароль можно только задать. В объекте хранится не сам пароль,
  // а его хеш SHA-256, поэтому прочитать пароль нельзя.
  public string Password {
    set {
      ValidatePassword(value);
      passwordHash = HashPassword(value);
    }
  }

  public bool HasPassword => passwordHash != null;

  public string AuthCode {
    get => authCode;
    set {
      string text = (value ?? string.Empty).Trim();

      if (!IsValidCode(text)) {
        throw new ArgumentException(
          "Код авторизации должен состоять из " + CodeLength + " цифр."
        );
      }

      authCode = text;
    }
  }

  // Причина, по которой не удалась последняя авторизация.
  public string ErrorMessage { get; protected set; }

  // Роль пользователя: гость, сотрудник или абитуриент.
  public abstract string Role { get; }

  // Папка, в которой хранятся файлы пользователей этого типа.
  public abstract string FolderName { get; }

  #region Виртуальные методы авторизации

  // Авторизация по паре логин/пароль.
  public virtual bool AuthorizeByPassword(string login, string password) {
    if (this.login != (login ?? string.Empty).Trim() || !CheckPassword(password)) {
      ErrorMessage = "Неверный логин или пароль.";
      return false;
    }

    ErrorMessage = null;
    return true;
  }

  // Авторизация по коду авторизации.
  public virtual bool AuthorizeByCode(string code) {
    if (!CheckCode(code)) {
      ErrorMessage = "Неверный код авторизации.";
      return false;
    }

    ErrorMessage = null;
    return true;
  }

  // Авторизация с помощью файла-ключа, содержащего код авторизации.
  // Код сравнивается методом CheckCode, а не виртуальным AuthorizeByCode,
  // чтобы дополнительные проверки производных классов выполнялись
  // один раз в их версии AuthorizeByKey и сообщение об отказе
  // не заменялось на «Файл-ключ недействителен.».
  public virtual bool AuthorizeByKey(string keyPath) {
    if (!File.Exists(keyPath)) {
      ErrorMessage = "Файл-ключ не найден.";
      return false;
    }

    if (!CheckCode(File.ReadAllText(keyPath))) {
      ErrorMessage = "Файл-ключ недействителен.";
      return false;
    }

    ErrorMessage = null;
    return true;
  }

  #endregion

  #region Виртуальные методы для работы с данными

  // Приветствие после успешной авторизации.
  public virtual string GetGreeting() {
    return "Добро пожаловать, " + login + "!";
  }

  // Поля пользователя для вывода в окне пользователя в виде пар
  // «название - значение». Пароль и код авторизации не выводятся.
  public virtual List<KeyValuePair<string, string>> GetFields() {
    return new List<KeyValuePair<string, string>> {
      new KeyValuePair<string, string>("Роль", Role),
      new KeyValuePair<string, string>(KeyLogin, Show(login))
    };
  }

  // Возвращает название первого незаполненного поля
  // или null, если заполнены все поля.
  public virtual string GetMissingField() {
    if (login == null) return KeyLogin;
    if (passwordHash == null) return "Пароль";
    if (authCode == null) return KeyAuthCode;

    return null;
  }

  // Данные пользователя для записи в файл.
  public virtual Dictionary<string, string> ToRecord() {
    return new Dictionary<string, string> {
      { KeyLogin, login },
      { KeyPasswordHash, passwordHash },
      { KeyAuthCode, authCode }
    };
  }

  // Заполняет объект данными, прочитанными из файла.
  // Значения проходят те же проверки, что и при регистрации.
  public virtual void FromRecord(Dictionary<string, string> record) {
    Login = GetValue(record, KeyLogin);
    AuthCode = GetValue(record, KeyAuthCode);
    passwordHash = GetValue(record, KeyPasswordHash);
  }

  #endregion

  // Проверяет, совпадает ли пароль с паролем пользователя.
  public bool CheckPassword(string password) {
    return passwordHash != null
           && password != null
           && passwordHash == HashPassword(password);
  }

  // Проверяет, совпадает ли код с кодом авторизации пользователя.
  public bool CheckCode(string code) {
    return authCode != null && authCode == (code ?? string.Empty).Trim();
  }

  #region Статические проверки

  public static bool IsValidLogin(string value) {
    return value != null
           && Regex.IsMatch(value, @"^[A-Za-z][A-Za-z0-9_]{3,19}$");
  }

  public static bool IsValidCode(string value) {
    return value != null
           && value.Length == CodeLength
           && value.All(c => c >= '0' && c <= '9');
  }

  // Пароль: не менее 8 символов, цифры, заглавные буквы,
  // специальные символы, без пробелов.
  public static void ValidatePassword(string value) {
    if (string.IsNullOrEmpty(value)) {
      throw new ArgumentException("Пароль не должен быть пустым.");
    }

    if (value.Length < MinPasswordLength) {
      throw new ArgumentException(
        "Пароль должен содержать не менее " + MinPasswordLength + " символов."
      );
    }

    if (value.Any(char.IsWhiteSpace)) {
      throw new ArgumentException("Пароль не должен содержать пробелов.");
    }

    if (!value.Any(char.IsDigit)) {
      throw new ArgumentException(
        "Пароль должен содержать хотя бы одну цифру."
      );
    }

    if (!value.Any(char.IsUpper)) {
      throw new ArgumentException(
        "Пароль должен содержать хотя бы одну заглавную букву."
      );
    }

    if (!value.Any(c => !char.IsLetterOrDigit(c))) {
      throw new ArgumentException(
        "Пароль должен содержать хотя бы один специальный символ "
        + "(например, ! @ # $ %)."
      );
    }
  }

  public static string HashPassword(string password) {
    using (SHA256 sha = SHA256.Create()) {
      byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
      StringBuilder result = new StringBuilder();

      foreach (byte b in hash) {
        result.Append(b.ToString("x2"));
      }

      return result.ToString();
    }
  }

  #endregion

  #region Вспомогательные методы для производных классов

  protected static string CheckInList(string value, string[] list, string name) {
    if (value == null || Array.IndexOf(list, value) < 0) {
      throw new ArgumentException("Выберите " + name + " из списка.");
    }

    return value;
  }

  protected static string GetValue(Dictionary<string, string> record, string key) {
    if (!record.TryGetValue(key, out string value)) {
      throw new FormatException(
        "В файле пользователя нет поля «" + key + "»."
      );
    }

    return value;
  }

  protected static string Show(string value) {
    return value ?? "не указано";
  }

  #endregion
}
}
