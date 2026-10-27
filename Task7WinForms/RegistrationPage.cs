using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GeneralUsers;
using Task7;

namespace Task7WinForms {
// Регистрация сотрудника, абитуриента или гостя.
public partial class RegistrationPage : UserControl {
  public RegistrationPage() {
    InitializeComponent();

    // Справочники отображаются в виде выпадающих списков.
    comboKind.Items.AddRange(Functions.KindNames);
    comboGender.Items.AddRange(Person.Genders);
    comboPosition.Items.AddRange(Employee.Positions);
    comboFaculty.Items.AddRange(Employee.Faculties);
    comboStatus.Items.AddRange(Employee.Statuses);
    comboSpeciality.Items.AddRange(Abiturient.Specialities);
    comboDocuments.Items.AddRange(Abiturient.DocumentStatuses);

    pickerBirthDate.MaxDate = DateTime.Today;
    pickerBirthDate.Value = DateTime.Today.AddYears(-20);
    comboKind.SelectedIndex = 0;
  }

  private UserKind SelectedKind => (UserKind)comboKind.SelectedIndex;

  private static void ShowError(string message) {
    MessageBox.Show(
      message,
      "Ошибка",
      MessageBoxButtons.OK,
      MessageBoxIcon.Error
    );
  }

  // Выполняет присваивание свойству в блоке try-catch.
  // Сообщение исключения добавляется в список ошибок.
  private static void TrySet(Action setter, List<string> errors) {
    try {
      setter();
    }
    catch (ArgumentException ex) {
      errors.Add(ex.Message);
    }
    catch (FormatException ex) {
      errors.Add(ex.Message);
    }
  }

  // Показывает поля, которые есть только у выбранного типа пользователя.
  private void comboKind_SelectedIndexChanged(object sender, EventArgs e) {
    groupEmployee.Visible = SelectedKind == UserKind.Employee;
    groupAbiturient.Visible = SelectedKind == UserKind.Abiturient;
  }

  private void btnGenerate_Click(object sender, EventArgs e) {
    try {
      boxCode.Text = Functions.GenerateCode(SelectedKind);
    }
    catch (Exception ex) {
      ShowError(ex.Message);
    }
  }

  private void btnRegister_Click(object sender, EventArgs e) {
    // Все типы пользователей - наследники Person.
    Person person = (Person)Functions.CreateUser(SelectedKind);
    List<string> errors = new List<string>();

    // Проверка вводимых значений выполняется свойствами классов.
    TrySet(() => person.FullName = boxFullName.Text, errors);
    TrySet(() => person.Gender = (string)comboGender.SelectedItem, errors);
    TrySet(() => person.BirthDate = pickerBirthDate.Value, errors);
    TrySet(() => person.Email = boxEmail.Text, errors);
    TrySet(() => person.Phone = boxPhone.Text, errors);

    if (person is Employee employee) {
      TrySet(() => employee.Position = (string)comboPosition.SelectedItem, errors);
      TrySet(() => employee.Faculty = (string)comboFaculty.SelectedItem, errors);
      TrySet(() => employee.Status = (string)comboStatus.SelectedItem, errors);
    }
    else if (person is Abiturient abiturient) {
      TrySet(() => abiturient.Speciality = (string)comboSpeciality.SelectedItem, errors);
      TrySet(() => abiturient.ExamScore = Abiturient.ParseScore(boxExamScore.Text), errors);
      TrySet(() => abiturient.DocumentsStatus = (string)comboDocuments.SelectedItem, errors);
    }

    TrySet(() => person.Login = boxLogin.Text, errors);
    TrySet(() => person.Password = boxPassword.Text, errors);

    if (boxPassword.Text != boxRepeat.Text) {
      errors.Add("Пароли не совпадают.");
    }

    TrySet(() => person.AuthCode = boxCode.Text, errors);

    if (errors.Count > 0) {
      ShowError(string.Join(Environment.NewLine, errors));
      return;
    }

    string path;

    try {
      path = Functions.Register(person);
    }
    catch (Exception ex) {
      ShowError(ex.Message);
      return;
    }

    string result =
      person.Role + " " + person.FullName + " зарегистрирован." + Environment.NewLine
      + "Файл пользователя: " + path + Environment.NewLine
      + "Код авторизации: " + person.AuthCode;

    if (checkKey.Checked) {
      saveKeyDialog.FileName = person.Login + ".key";

      if (saveKeyDialog.ShowDialog() == DialogResult.OK) {
        try {
          Functions.SaveKeyFile(saveKeyDialog.FileName, person.AuthCode);
          result += Environment.NewLine + "Файл-ключ: " + saveKeyDialog.FileName;
        }
        catch (Exception ex) {
          ShowError("Не удалось создать файл-ключ: " + ex.Message);
        }
      }
    }

    MessageBox.Show(
      result,
      "Готово",
      MessageBoxButtons.OK,
      MessageBoxIcon.Information
    );

    ClearFields();
  }

  private void btnClear_Click(object sender, EventArgs e) {
    ClearFields();
  }

  private void ClearFields() {
    foreach (TextBox box in new[] {
               boxFullName, boxEmail, boxPhone, boxExamScore,
               boxLogin, boxPassword, boxRepeat, boxCode
             }) {
      box.Clear();
    }

    foreach (ComboBox box in new[] {
               comboGender, comboPosition, comboFaculty, comboStatus,
               comboSpeciality, comboDocuments
             }) {
      box.SelectedIndex = -1;
    }

    pickerBirthDate.Value = DateTime.Today.AddYears(-20);
    checkKey.Checked = true;
  }
}
}
