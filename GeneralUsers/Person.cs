using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace GeneralUsers {
// Человек. Базовый класс для сотрудника и абитуриента.
// Сюда перенесены личные данные, которые раньше были в Employee.
// Объект самого класса Person используется для авторизации гостя.
public class Person : User {
  public static readonly string[] Genders = {
    "Мужской",
    "Женский"
  };

  public const string DateFormat = "dd.MM.yyyy";
  public const int MaxAge = 100;

  public const string KeyFullName = "ФИО";
  public const string KeyGender = "Пол";
  public const string KeyBirthDate = "Дата рождения";
  public const string KeyEmail = "E-mail";
  public const string KeyPhone = "Телефон";

  private string fullName;
  private string gender;
  private DateTime birthDate;
  private string email;
  private string phone;

  public string FullName {
    get => fullName;
    set {
      string text = NormalizeSpaces(value);

      if (text.Length == 0) {
        throw new ArgumentException("ФИО не должно быть пустым.");
      }

      string[] words = text.Split(' ');

      if (words.Length < 2 || words.Length > 3) {
        throw new ArgumentException(
          "ФИО должно состоять из 2 или 3 слов (фамилия, имя, отчество)."
        );
      }

      foreach (string word in words) {
        if (!word.All(c => char.IsLetter(c) || c == '-')
            || word.StartsWith("-")
            || word.EndsWith("-")) {
          throw new ArgumentException(
            "ФИО может содержать только буквы и дефис."
          );
        }

        if (!char.IsUpper(word[0])) {
          throw new ArgumentException(
            "Каждое слово ФИО должно начинаться с заглавной буквы."
          );
        }
      }

      fullName = text;
    }
  }

  public string Gender {
    get => gender;
    set => gender = CheckInList(value, Genders, "пол");
  }

  // Допустимый возраст зависит от роли, поэтому нижняя граница
  // берётся из виртуального свойства MinAge.
  public DateTime BirthDate {
    get => birthDate;
    set {
      DateTime date = value.Date;

      if (date > DateTime.Today) {
        throw new ArgumentException(
          "Дата рождения не может быть в будущем."
        );
      }

      int age = GetAge(date, DateTime.Today);

      if (age < MinAge || age > MaxAge) {
        throw new ArgumentException(
          "Возраст пользователя с ролью «" + Role + "» должен быть от "
          + MinAge + " до " + MaxAge + " лет."
        );
      }

      birthDate = date;
    }
  }

  // Возраст вычисляется по дате рождения, поэтому свойство только для чтения.
  public int Age => GetAge(birthDate, DateTime.Today);

  public string Email {
    get => email;
    set {
      string text = (value ?? string.Empty).Trim();

      if (!Regex.IsMatch(text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) {
        throw new ArgumentException(
          "E-mail должен иметь вид имя@домен.зона."
        );
      }

      email = text;
    }
  }

  // Телефон хранится в виде +7XXXXXXXXXX.
  public string Phone {
    get => phone;
    set {
      string text = (value ?? string.Empty).Trim();

      if (!text.All(c => char.IsDigit(c) || "+-() ".IndexOf(c) >= 0)) {
        throw new ArgumentException(
          "Телефон может содержать только цифры, пробелы и символы + - ( )."
        );
      }

      string digits = new string(text.Where(char.IsDigit).ToArray());

      if (digits.Length != 11 || (digits[0] != '7' && digits[0] != '8')) {
        throw new ArgumentException(
          "Телефон должен быть в формате +7XXXXXXXXXX или 8XXXXXXXXXX."
        );
      }

      phone = "+7" + digits.Substring(1);
    }
  }

  // Минимальный возраст. Переопределяется в производных классах.
  public virtual int MinAge => 14;

  public override string Role => "Гость";

  public override string FolderName => "guests";

  public override string GetGreeting() {
    return "Здравствуйте, " + fullName + "! Вы вошли как гость.";
  }

  public override List<KeyValuePair<string, string>> GetFields() {
    List<KeyValuePair<string, string>> fields = base.GetFields();

    fields.Add(new KeyValuePair<string, string>(KeyFullName, Show(fullName)));
    fields.Add(new KeyValuePair<string, string>(KeyGender, Show(gender)));
    fields.Add(new KeyValuePair<string, string>(
      KeyBirthDate,
      birthDate == default(DateTime) ? Show(null) : FormatDate(birthDate)
    ));
    fields.Add(new KeyValuePair<string, string>(
      "Возраст",
      birthDate == default(DateTime) ? Show(null) : Age.ToString()
    ));
    fields.Add(new KeyValuePair<string, string>(KeyEmail, Show(email)));
    fields.Add(new KeyValuePair<string, string>(KeyPhone, Show(phone)));

    return fields;
  }

  public override string GetMissingField() {
    if (fullName == null) return KeyFullName;
    if (gender == null) return KeyGender;
    if (birthDate == default(DateTime)) return KeyBirthDate;
    if (email == null) return KeyEmail;
    if (phone == null) return KeyPhone;

    return base.GetMissingField();
  }

  public override Dictionary<string, string> ToRecord() {
    Dictionary<string, string> record = new Dictionary<string, string> {
      { KeyFullName, fullName },
      { KeyGender, gender },
      { KeyBirthDate, FormatDate(birthDate) },
      { KeyEmail, email },
      { KeyPhone, phone }
    };

    foreach (KeyValuePair<string, string> pair in base.ToRecord()) {
      record.Add(pair.Key, pair.Value);
    }

    return record;
  }

  public override void FromRecord(Dictionary<string, string> record) {
    FullName = GetValue(record, KeyFullName);
    Gender = GetValue(record, KeyGender);
    BirthDate = ParseDate(GetValue(record, KeyBirthDate));
    Email = GetValue(record, KeyEmail);
    Phone = GetValue(record, KeyPhone);

    base.FromRecord(record);
  }

  public override string ToString() {
    return fullName + " (" + Role.ToLower() + ")";
  }

  public static DateTime ParseDate(string value) {
    if (!DateTime.TryParseExact(
          (value ?? string.Empty).Trim(),
          DateFormat,
          CultureInfo.InvariantCulture,
          DateTimeStyles.None,
          out DateTime date
        )) {
      throw new FormatException("Дата должна быть в формате дд.мм.гггг.");
    }

    return date;
  }

  public static string FormatDate(DateTime date) {
    return date.ToString(DateFormat, CultureInfo.InvariantCulture);
  }

  private static int GetAge(DateTime birth, DateTime today) {
    int age = today.Year - birth.Year;

    if (birth > today.AddYears(-age)) {
      age--;
    }

    return age;
  }

  private static string NormalizeSpaces(string value) {
    return string.Join(
      " ",
      (value ?? string.Empty).Split(
        new[] { ' ', '\t' },
        StringSplitOptions.RemoveEmptyEntries
      )
    );
  }
}
}
