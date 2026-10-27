using System;
using System.IO;
using GeneralConsole;
using GeneralUsers;
using Task7;

namespace Task7Console {
public static class Ui {
  private static readonly string[] Methods = {
    "Логин и пароль",
    "Код авторизации",
    "Файл-ключ"
  };

  // Регистрация сотрудника, абитуриента или гостя.
  public static void RegistrationUi() {
    Console.WriteLine("Регистрация нового пользователя\n");

    UserKind kind = (UserKind)Helpers.ReadChoice(
      "Тип пользователя:",
      Functions.KindNames
    );

    // Все типы пользователей - наследники Person, поэтому личные
    // данные вводятся одинаково, а дополнительные поля - по типу объекта.
    Person person = (Person)Functions.CreateUser(kind);

    Console.WriteLine("\nЛичные данные");
    ReadPersonalData(person);

    if (person is Employee employee) {
      ReadEmployeeData(employee);
    }
    else if (person is Abiturient abiturient) {
      ReadAbiturientData(abiturient);
    }

    Console.WriteLine("\nДанные для авторизации");
    ReadAuthData(kind, person);

    string path;

    try {
      path = Functions.Register(person);
    }
    catch (Exception ex) {
      Console.WriteLine("\nОшибка регистрации: {0}", ex.Message);
      return;
    }

    Console.WriteLine("\nПользователь зарегистрирован ({0}).", person.Role);
    Console.WriteLine("Файл пользователя: {0}", path);
    Console.WriteLine("Код авторизации: {0}", person.AuthCode);

    string keyPath = Helpers.ReadLine(
      "\nПуть к файлу-ключу (пустая строка - не создавать): "
    ).Trim();

    if (keyPath.Length == 0) {
      return;
    }

    try {
      Functions.SaveKeyFile(keyPath, person.AuthCode);
      Console.WriteLine("Файл-ключ создан: {0}", Path.GetFullPath(keyPath));
    }
    catch (Exception ex) {
      Console.WriteLine("Не удалось создать файл-ключ: {0}", ex.Message);
    }
  }

  // Авторизация сотрудника, абитуриента или гостя.
  // После успешной авторизации открывается окно пользователя (задание 8).
  public static void Task7Ui() {
    Console.WriteLine("Авторизация пользователя\n");

    UserKind kind = (UserKind)Helpers.ReadChoice(
      "Кто входит в систему:",
      Functions.KindNames
    );

    int method = Helpers.ReadChoice("\nСпособ авторизации:", Methods);

    User user;
    string message;

    try {
      switch (method) {
        case 0:
          string login = Helpers.ReadString("Логин: ");
          string password = Helpers.ReadPassword("Пароль: ");
          user = Functions.ByPassword(kind, login, password, out message);
          break;
        case 1:
          string code = Helpers.ReadString("Код авторизации: ");
          user = Functions.ByCode(kind, code, out message);
          break;
        default:
          string keyPath = Helpers.ReadString("Путь к файлу-ключу: ");
          user = Functions.ByKey(kind, keyPath, out message);
          break;
      }
    }
    catch (Exception ex) {
      Console.WriteLine("\nОшибка авторизации: {0}", ex.Message);
      Helpers.Pause();
      return;
    }

    if (user == null) {
      Console.WriteLine("\nАвторизация не выполнена. {0}", message);
      Helpers.Pause();
      return;
    }

    Console.WriteLine("\nАвторизация выполнена успешно. {0}", message);
    Helpers.Pause();

    Task8Console.Ui.Task8Ui(user);
  }

  // Ввод личных данных. Каждое значение присваивается свойству объекта;
  // при ошибке свойство генерирует исключение и ввод повторяется.
  private static void ReadPersonalData(Person person) {
    Helpers.ReadValid("ФИО: ", value => person.FullName = value);

    person.Gender = Person.Genders[
      Helpers.ReadChoice("Пол:", Person.Genders)
    ];

    Helpers.ReadValid(
      "Дата рождения (дд.мм.гггг): ",
      value => person.BirthDate = Person.ParseDate(value)
    );

    Helpers.ReadValid("E-mail: ", value => person.Email = value);

    Helpers.ReadValid(
      "Телефон (+7XXXXXXXXXX): ",
      value => person.Phone = value
    );
  }

  private static void ReadEmployeeData(Employee employee) {
    Console.WriteLine("\nДанные сотрудника");

    employee.Position = Employee.Positions[
      Helpers.ReadChoice("Должность:", Employee.Positions)
    ];

    employee.Faculty = Employee.Faculties[
      Helpers.ReadChoice("Факультет:", Employee.Faculties)
    ];

    employee.Status = Employee.Statuses[
      Helpers.ReadChoice("Статус:", Employee.Statuses)
    ];
  }

  private static void ReadAbiturientData(Abiturient abiturient) {
    Console.WriteLine("\nДанные абитуриента");

    abiturient.Speciality = Abiturient.Specialities[
      Helpers.ReadChoice("Направление подготовки:", Abiturient.Specialities)
    ];

    Helpers.ReadValid(
      "Сумма баллов ЕГЭ: ",
      value => abiturient.ExamScore = Abiturient.ParseScore(value)
    );

    abiturient.DocumentsStatus = Abiturient.DocumentStatuses[
      Helpers.ReadChoice("Документы:", Abiturient.DocumentStatuses)
    ];
  }

  private static void ReadAuthData(UserKind kind, User user) {
    Helpers.ReadValid("Логин: ", value => {
      user.Login = value;

      if (Functions.LoginExists(kind, user.Login)) {
        throw new ArgumentException("Такой логин уже занят!");
      }
    });

    while (true) {
      Helpers.ReadValid(
        "Пароль (не менее 8 символов, цифры, заглавные буквы, "
        + "спецсимволы, без пробелов): ",
        value => user.Password = value,
        true
      );

      string repeat = Helpers.ReadPassword("Повторите пароль: ");

      if (user.CheckPassword(repeat)) {
        break;
      }

      Console.WriteLine("Пароли не совпадают!");
    }

    Helpers.ReadValid(
      "Код авторизации (6 цифр, пустая строка - сгенерировать): ",
      value => {
        user.AuthCode = string.IsNullOrWhiteSpace(value)
          ? Functions.GenerateCode(kind)
          : value;

        if (Functions.CodeExists(kind, user.AuthCode)) {
          throw new ArgumentException("Такой код уже используется!");
        }
      }
    );
  }
}
}
