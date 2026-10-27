using System;
using System.Collections.Generic;

namespace GeneralUsers {
// Сотрудник вуза. Личные данные и данные для авторизации
// наследуются от Person и User, здесь остались только
// члены класса, относящиеся к работе в вузе.
public class Employee : Person {
  public static readonly string[] Positions = {
    "Ассистент",
    "Преподаватель",
    "Старший преподаватель",
    "Доцент",
    "Профессор",
    "Заведующий кафедрой",
    "Декан",
    "Лаборант",
    "Методист"
  };

  public static readonly string[] Faculties = {
    "Факультет информационных технологий",
    "Экономический факультет",
    "Юридический факультет",
    "Инженерный факультет",
    "Гуманитарный факультет",
    "Факультет естественных наук"
  };

  public static readonly string[] Statuses = {
    "Работает",
    "В отпуске",
    "Уволен"
  };

  public const string StatusFired = "Уволен";

  public const string KeyPosition = "Должность";
  public const string KeyFaculty = "Факультет";
  public const string KeyStatus = "Статус";

  private string position;
  private string faculty;
  private string status;

  public string Position {
    get => position;
    set => position = CheckInList(value, Positions, "должность");
  }

  public string Faculty {
    get => faculty;
    set => faculty = CheckInList(value, Faculties, "факультет");
  }

  public string Status {
    get => status;
    set => status = CheckInList(value, Statuses, "статус");
  }

  public override int MinAge => 18;

  public override string Role => "Сотрудник";

  public override string FolderName => "employees";

  // Уволенный сотрудник не может войти в систему,
  // даже если данные для входа указаны верно.
  public override bool AuthorizeByPassword(string login, string password) {
    return base.AuthorizeByPassword(login, password) && CheckStatus();
  }

  public override bool AuthorizeByCode(string code) {
    return base.AuthorizeByCode(code) && CheckStatus();
  }

  public override bool AuthorizeByKey(string keyPath) {
    return base.AuthorizeByKey(keyPath) && CheckStatus();
  }

  public override string GetGreeting() {
    return "Здравствуйте, " + FullName + "! Вы вошли как сотрудник ("
           + position.ToLower() + ").";
  }

  public override List<KeyValuePair<string, string>> GetFields() {
    List<KeyValuePair<string, string>> fields = base.GetFields();

    fields.Add(new KeyValuePair<string, string>(KeyPosition, Show(position)));
    fields.Add(new KeyValuePair<string, string>(KeyFaculty, Show(faculty)));
    fields.Add(new KeyValuePair<string, string>(KeyStatus, Show(status)));

    return fields;
  }

  public override string GetMissingField() {
    if (position == null) return KeyPosition;
    if (faculty == null) return KeyFaculty;
    if (status == null) return KeyStatus;

    return base.GetMissingField();
  }

  public override Dictionary<string, string> ToRecord() {
    Dictionary<string, string> record = base.ToRecord();

    record.Add(KeyPosition, position);
    record.Add(KeyFaculty, faculty);
    record.Add(KeyStatus, status);

    return record;
  }

  public override void FromRecord(Dictionary<string, string> record) {
    base.FromRecord(record);

    Position = GetValue(record, KeyPosition);
    Faculty = GetValue(record, KeyFaculty);
    Status = GetValue(record, KeyStatus);
  }

  private bool CheckStatus() {
    if (status == StatusFired) {
      ErrorMessage = "Сотрудник уволен, вход в систему запрещён.";
      return false;
    }

    return true;
  }
}
}
