using System;
using System.Collections.Generic;

namespace GeneralUsers {
// Абитуриент - человек, подавший документы для поступления в вуз.
public class Abiturient : Person {
  public static readonly string[] Specialities = {
    "09.03.01 Информатика и вычислительная техника",
    "09.03.02 Информационные системы и технологии",
    "09.03.03 Прикладная информатика",
    "38.03.01 Экономика",
    "40.03.01 Юриспруденция"
  };

  public static readonly string[] DocumentStatuses = {
    "Поданы",
    "Отозваны"
  };

  public const string DocumentsWithdrawn = "Отозваны";
  public const int MaxExamScore = 310;

  public const string KeySpeciality = "Направление";
  public const string KeyExamScore = "Сумма баллов ЕГЭ";
  public const string KeyDocuments = "Документы";

  private string speciality;
  private int examScore = -1;
  private string documentsStatus;

  public string Speciality {
    get => speciality;
    set => speciality = CheckInList(value, Specialities, "направление подготовки");
  }

  public int ExamScore {
    get => examScore;
    set {
      if (value < 0 || value > MaxExamScore) {
        throw new ArgumentException(
          "Сумма баллов ЕГЭ должна быть от 0 до " + MaxExamScore + "."
        );
      }

      examScore = value;
    }
  }

  public string DocumentsStatus {
    get => documentsStatus;
    set => documentsStatus = CheckInList(value, DocumentStatuses, "статус документов");
  }

  public override string Role => "Абитуриент";

  public override string FolderName => "abiturients";

  // Абитуриент, отозвавший документы, не может войти в систему.
  public override bool AuthorizeByPassword(string login, string password) {
    return base.AuthorizeByPassword(login, password) && CheckDocuments();
  }

  public override bool AuthorizeByCode(string code) {
    return base.AuthorizeByCode(code) && CheckDocuments();
  }

  public override bool AuthorizeByKey(string keyPath) {
    return base.AuthorizeByKey(keyPath) && CheckDocuments();
  }

  public override string GetGreeting() {
    return "Здравствуйте, " + FullName + "! Вы вошли как абитуриент "
           + "направления " + speciality + ".";
  }

  public override List<KeyValuePair<string, string>> GetFields() {
    List<KeyValuePair<string, string>> fields = base.GetFields();

    fields.Add(new KeyValuePair<string, string>(KeySpeciality, Show(speciality)));
    fields.Add(new KeyValuePair<string, string>(
      KeyExamScore,
      examScore < 0 ? Show(null) : examScore.ToString()
    ));
    fields.Add(new KeyValuePair<string, string>(KeyDocuments, Show(documentsStatus)));

    return fields;
  }

  public override string GetMissingField() {
    if (speciality == null) return KeySpeciality;
    if (examScore < 0) return KeyExamScore;
    if (documentsStatus == null) return KeyDocuments;

    return base.GetMissingField();
  }

  public override Dictionary<string, string> ToRecord() {
    Dictionary<string, string> record = base.ToRecord();

    record.Add(KeySpeciality, speciality);
    record.Add(KeyExamScore, examScore.ToString());
    record.Add(KeyDocuments, documentsStatus);

    return record;
  }

  public override void FromRecord(Dictionary<string, string> record) {
    base.FromRecord(record);

    Speciality = GetValue(record, KeySpeciality);
    ExamScore = ParseScore(GetValue(record, KeyExamScore));
    DocumentsStatus = GetValue(record, KeyDocuments);
  }

  // Преобразует введённый текст в сумму баллов.
  public static int ParseScore(string value) {
    if (!int.TryParse((value ?? string.Empty).Trim(), out int score)) {
      throw new FormatException("Сумма баллов ЕГЭ должна быть целым числом.");
    }

    return score;
  }

  private bool CheckDocuments() {
    if (documentsStatus == DocumentsWithdrawn) {
      ErrorMessage = "Абитуриент отозвал документы, вход в систему запрещён.";
      return false;
    }

    return true;
  }
}
}
