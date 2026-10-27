using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GeneralUsers;

namespace Task7 {
// Тип пользователя, который регистрируется или входит в систему.
public enum UserKind {
  Employee,
  Abiturient,
  Guest
}

// Регистрация и авторизация сотрудника, абитуриента и гостя.
public static class Functions {
  private static readonly Random Random = new Random();

  // Названия типов пользователей в порядке перечисления UserKind.
  public static readonly string[] KindNames = {
    "Сотрудник",
    "Абитуриент",
    "Гость"
  };

  // Создаёт пустой объект нужного класса. Переменная базового типа User
  // может ссылаться на объект любого производного класса.
  public static User CreateUser(UserKind kind) {
    switch (kind) {
      case UserKind.Employee:
        return new Employee();
      case UserKind.Abiturient:
        return new Abiturient();
      default:
        return new Person();
    }
  }

  public static string GetFolderName(UserKind kind) {
    return CreateUser(kind).FolderName;
  }

  public static bool LoginExists(UserKind kind, string login) {
    return LoginExists(GetFolderName(kind), login);
  }

  public static bool CodeExists(UserKind kind, string code) {
    return CodeExists(GetFolderName(kind), code);
  }

  private static bool LoginExists(string folderName, string login) {
    return File.Exists(Storage.GetFilePath(folderName, login));
  }

  private static bool CodeExists(string folderName, string code) {
    return FindRecord(folderName, User.KeyAuthCode, code) != null;
  }

  // Создаёт случайный код авторизации, который ещё не используется.
  public static string GenerateCode(UserKind kind) {
    string code;

    do {
      code = Random.Next(0, 1000000).ToString("D" + User.CodeLength);
    } while (CodeExists(kind, code));

    return code;
  }

  // Сохраняет пользователя в новый файл в папке его типа.
  // Возвращает путь к созданному файлу.
  public static string Register(User user) {
    string missing = user.GetMissingField();

    if (missing != null) {
      throw new InvalidOperationException(
        "Не заполнено поле «" + missing + "»."
      );
    }

    if (LoginExists(user.FolderName, user.Login)) {
      throw new InvalidOperationException(
        "Пользователь с логином «" + user.Login + "» уже зарегистрирован."
      );
    }

    if (CodeExists(user.FolderName, user.AuthCode)) {
      throw new InvalidOperationException(
        "Такой код авторизации уже используется. Укажите другой код."
      );
    }

    string path = Storage.GetFilePath(user.FolderName, user.Login);
    Storage.Write(path, user.ToRecord());

    return path;
  }

  // Создаёт файл-ключ, содержащий код авторизации.
  public static void SaveKeyFile(string path, string code) {
    File.WriteAllText(path, code, new UTF8Encoding(false));
  }

  #region Авторизация

  // Во всех методах объект нужного класса заполняется данными из файла,
  // после чего вызывается его виртуальный метод авторизации. Какая версия
  // метода выполнится (User, Employee или Abiturient), определяется типом
  // объекта. Объект возвращается только при успешной авторизации,
  // иначе возвращается null, а в message - причина отказа.

  // Авторизация по паре логин/пароль.
  public static User ByPassword(
    UserKind kind,
    string login,
    string password,
    out string message
  ) {
    login = (login ?? string.Empty).Trim();
    Dictionary<string, string> record = null;

    if (User.IsValidLogin(login)) {
      string path = Storage.GetFilePath(GetFolderName(kind), login);

      if (File.Exists(path)) {
        record = Storage.Read(path);
      }
    }

    User user = Load(kind, record);

    if (user == null) {
      message = "Неверный логин или пароль.";
      return null;
    }

    return Check(user, user.AuthorizeByPassword(login, password), out message);
  }

  // Авторизация по коду авторизации.
  public static User ByCode(UserKind kind, string code, out string message) {
    code = (code ?? string.Empty).Trim();

    User user = User.IsValidCode(code)
      ? Load(kind, FindRecord(GetFolderName(kind), User.KeyAuthCode, code))
      : null;

    if (user == null) {
      message = "Пользователь с таким кодом авторизации не найден.";
      return null;
    }

    return Check(user, user.AuthorizeByCode(code), out message);
  }

  // Авторизация с помощью файла-ключа, содержащего код авторизации.
  public static User ByKey(UserKind kind, string keyPath, out string message) {
    if (!File.Exists(keyPath)) {
      throw new FileNotFoundException("Файл-ключ не найден.", keyPath);
    }

    string code = File.ReadAllText(keyPath).Trim();

    User user = User.IsValidCode(code)
      ? Load(kind, FindRecord(GetFolderName(kind), User.KeyAuthCode, code))
      : null;

    if (user == null) {
      message = "Файл-ключ недействителен.";
      return null;
    }

    return Check(user, user.AuthorizeByKey(keyPath), out message);
  }

  #endregion

  // Ищет в папке пользователей запись, у которой поле key равно value.
  private static Dictionary<string, string> FindRecord(
    string folderName,
    string key,
    string value
  ) {
    foreach (string file in Storage.GetFiles(folderName)) {
      Dictionary<string, string> record = Storage.Read(file);

      if (record.TryGetValue(key, out string current) && current == value) {
        return record;
      }
    }

    return null;
  }

  // Создаёт объект нужного класса и заполняет его данными из файла.
  private static User Load(UserKind kind, Dictionary<string, string> record) {
    if (record == null) {
      return null;
    }

    User user = CreateUser(kind);
    user.FromRecord(record);

    return user;
  }

  private static User Check(User user, bool success, out string message) {
    if (!success) {
      message = user.ErrorMessage;
      return null;
    }

    message = user.GetGreeting();
    return user;
  }
}
}
