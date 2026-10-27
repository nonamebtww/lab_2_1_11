namespace Task7WinForms {
partial class RegistrationPage {
  private System.ComponentModel.IContainer components = null;

  private System.Windows.Forms.Label labelKind;
  private System.Windows.Forms.ComboBox comboKind;
  private System.Windows.Forms.GroupBox groupPerson;
  private System.Windows.Forms.Label labelFullName;
  private System.Windows.Forms.TextBox boxFullName;
  private System.Windows.Forms.Label labelGender;
  private System.Windows.Forms.ComboBox comboGender;
  private System.Windows.Forms.Label labelBirthDate;
  private System.Windows.Forms.DateTimePicker pickerBirthDate;
  private System.Windows.Forms.Label labelEmail;
  private System.Windows.Forms.TextBox boxEmail;
  private System.Windows.Forms.Label labelPhone;
  private System.Windows.Forms.TextBox boxPhone;
  private System.Windows.Forms.GroupBox groupAuth;
  private System.Windows.Forms.Label labelLogin;
  private System.Windows.Forms.TextBox boxLogin;
  private System.Windows.Forms.Label labelPassword;
  private System.Windows.Forms.TextBox boxPassword;
  private System.Windows.Forms.Label labelRepeat;
  private System.Windows.Forms.TextBox boxRepeat;
  private System.Windows.Forms.Label labelCode;
  private System.Windows.Forms.TextBox boxCode;
  private System.Windows.Forms.Button btnGenerate;
  private System.Windows.Forms.CheckBox checkKey;
  private System.Windows.Forms.GroupBox groupEmployee;
  private System.Windows.Forms.Label labelPosition;
  private System.Windows.Forms.ComboBox comboPosition;
  private System.Windows.Forms.Label labelFaculty;
  private System.Windows.Forms.ComboBox comboFaculty;
  private System.Windows.Forms.Label labelStatus;
  private System.Windows.Forms.ComboBox comboStatus;
  private System.Windows.Forms.GroupBox groupAbiturient;
  private System.Windows.Forms.Label labelSpeciality;
  private System.Windows.Forms.ComboBox comboSpeciality;
  private System.Windows.Forms.Label labelExamScore;
  private System.Windows.Forms.TextBox boxExamScore;
  private System.Windows.Forms.Label labelDocuments;
  private System.Windows.Forms.ComboBox comboDocuments;
  private System.Windows.Forms.Button btnRegister;
  private System.Windows.Forms.Button btnClear;
  private System.Windows.Forms.SaveFileDialog saveKeyDialog;

  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }

    base.Dispose(disposing);
  }

  #region Component Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
    this.labelKind = new System.Windows.Forms.Label();
    this.comboKind = new System.Windows.Forms.ComboBox();
    this.groupPerson = new System.Windows.Forms.GroupBox();
    this.labelFullName = new System.Windows.Forms.Label();
    this.boxFullName = new System.Windows.Forms.TextBox();
    this.labelGender = new System.Windows.Forms.Label();
    this.comboGender = new System.Windows.Forms.ComboBox();
    this.labelBirthDate = new System.Windows.Forms.Label();
    this.pickerBirthDate = new System.Windows.Forms.DateTimePicker();
    this.labelEmail = new System.Windows.Forms.Label();
    this.boxEmail = new System.Windows.Forms.TextBox();
    this.labelPhone = new System.Windows.Forms.Label();
    this.boxPhone = new System.Windows.Forms.TextBox();
    this.groupAuth = new System.Windows.Forms.GroupBox();
    this.labelLogin = new System.Windows.Forms.Label();
    this.boxLogin = new System.Windows.Forms.TextBox();
    this.labelPassword = new System.Windows.Forms.Label();
    this.boxPassword = new System.Windows.Forms.TextBox();
    this.labelRepeat = new System.Windows.Forms.Label();
    this.boxRepeat = new System.Windows.Forms.TextBox();
    this.labelCode = new System.Windows.Forms.Label();
    this.boxCode = new System.Windows.Forms.TextBox();
    this.btnGenerate = new System.Windows.Forms.Button();
    this.checkKey = new System.Windows.Forms.CheckBox();
    this.groupEmployee = new System.Windows.Forms.GroupBox();
    this.labelPosition = new System.Windows.Forms.Label();
    this.comboPosition = new System.Windows.Forms.ComboBox();
    this.labelFaculty = new System.Windows.Forms.Label();
    this.comboFaculty = new System.Windows.Forms.ComboBox();
    this.labelStatus = new System.Windows.Forms.Label();
    this.comboStatus = new System.Windows.Forms.ComboBox();
    this.groupAbiturient = new System.Windows.Forms.GroupBox();
    this.labelSpeciality = new System.Windows.Forms.Label();
    this.comboSpeciality = new System.Windows.Forms.ComboBox();
    this.labelExamScore = new System.Windows.Forms.Label();
    this.boxExamScore = new System.Windows.Forms.TextBox();
    this.labelDocuments = new System.Windows.Forms.Label();
    this.comboDocuments = new System.Windows.Forms.ComboBox();
    this.btnRegister = new System.Windows.Forms.Button();
    this.btnClear = new System.Windows.Forms.Button();
    this.saveKeyDialog = new System.Windows.Forms.SaveFileDialog();
    this.groupPerson.SuspendLayout();
    this.groupAuth.SuspendLayout();
    this.groupEmployee.SuspendLayout();
    this.groupAbiturient.SuspendLayout();
    this.saveKeyDialog.DefaultExt = "key";
    this.saveKeyDialog.Filter = "Файл-ключ (*.key)|*.key|Все файлы (*.*)|*.*";
    this.SuspendLayout();
    // 
    // labelKind
    // 
    this.labelKind.AutoSize = true;
    this.labelKind.Location = new System.Drawing.Point(12, 15);
    this.labelKind.Name = "labelKind";
    this.labelKind.Text = "Тип пользователя:";
    // 
    // comboKind
    // 
    this.comboKind.Location = new System.Drawing.Point(130, 12);
    this.comboKind.Name = "comboKind";
    this.comboKind.Size = new System.Drawing.Size(200, 20);
    this.comboKind.TabIndex = 0;
    this.comboKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    this.comboKind.SelectedIndexChanged += new System.EventHandler(this.comboKind_SelectedIndexChanged);
    // 
    // groupPerson
    // 
    this.groupPerson.Controls.Add(this.labelFullName);
    this.groupPerson.Controls.Add(this.boxFullName);
    this.groupPerson.Controls.Add(this.labelGender);
    this.groupPerson.Controls.Add(this.comboGender);
    this.groupPerson.Controls.Add(this.labelBirthDate);
    this.groupPerson.Controls.Add(this.pickerBirthDate);
    this.groupPerson.Controls.Add(this.labelEmail);
    this.groupPerson.Controls.Add(this.boxEmail);
    this.groupPerson.Controls.Add(this.labelPhone);
    this.groupPerson.Controls.Add(this.boxPhone);
    this.groupPerson.Location = new System.Drawing.Point(12, 45);
    this.groupPerson.Name = "groupPerson";
    this.groupPerson.Size = new System.Drawing.Size(360, 185);
    this.groupPerson.TabIndex = 1;
    this.groupPerson.Text = "Личные данные";
    // 
    // labelFullName
    // 
    this.labelFullName.AutoSize = true;
    this.labelFullName.Location = new System.Drawing.Point(10, 28);
    this.labelFullName.Name = "labelFullName";
    this.labelFullName.Text = "ФИО:";
    // 
    // boxFullName
    // 
    this.boxFullName.Location = new System.Drawing.Point(120, 25);
    this.boxFullName.Name = "boxFullName";
    this.boxFullName.Size = new System.Drawing.Size(225, 20);
    this.boxFullName.TabIndex = 0;
    // 
    // labelGender
    // 
    this.labelGender.AutoSize = true;
    this.labelGender.Location = new System.Drawing.Point(10, 58);
    this.labelGender.Name = "labelGender";
    this.labelGender.Text = "Пол:";
    // 
    // comboGender
    // 
    this.comboGender.Location = new System.Drawing.Point(120, 55);
    this.comboGender.Name = "comboGender";
    this.comboGender.Size = new System.Drawing.Size(150, 20);
    this.comboGender.TabIndex = 1;
    this.comboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    // 
    // labelBirthDate
    // 
    this.labelBirthDate.AutoSize = true;
    this.labelBirthDate.Location = new System.Drawing.Point(10, 88);
    this.labelBirthDate.Name = "labelBirthDate";
    this.labelBirthDate.Text = "Дата рождения:";
    // 
    // pickerBirthDate
    // 
    this.pickerBirthDate.Location = new System.Drawing.Point(120, 85);
    this.pickerBirthDate.Name = "pickerBirthDate";
    this.pickerBirthDate.Size = new System.Drawing.Size(150, 20);
    this.pickerBirthDate.TabIndex = 2;
    this.pickerBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
    // 
    // labelEmail
    // 
    this.labelEmail.AutoSize = true;
    this.labelEmail.Location = new System.Drawing.Point(10, 118);
    this.labelEmail.Name = "labelEmail";
    this.labelEmail.Text = "E-mail:";
    // 
    // boxEmail
    // 
    this.boxEmail.Location = new System.Drawing.Point(120, 115);
    this.boxEmail.Name = "boxEmail";
    this.boxEmail.Size = new System.Drawing.Size(225, 20);
    this.boxEmail.TabIndex = 3;
    // 
    // labelPhone
    // 
    this.labelPhone.AutoSize = true;
    this.labelPhone.Location = new System.Drawing.Point(10, 148);
    this.labelPhone.Name = "labelPhone";
    this.labelPhone.Text = "Телефон:";
    // 
    // boxPhone
    // 
    this.boxPhone.Location = new System.Drawing.Point(120, 145);
    this.boxPhone.Name = "boxPhone";
    this.boxPhone.Size = new System.Drawing.Size(150, 20);
    this.boxPhone.TabIndex = 4;
    // 
    // groupAuth
    // 
    this.groupAuth.Controls.Add(this.labelLogin);
    this.groupAuth.Controls.Add(this.boxLogin);
    this.groupAuth.Controls.Add(this.labelPassword);
    this.groupAuth.Controls.Add(this.boxPassword);
    this.groupAuth.Controls.Add(this.labelRepeat);
    this.groupAuth.Controls.Add(this.boxRepeat);
    this.groupAuth.Controls.Add(this.labelCode);
    this.groupAuth.Controls.Add(this.boxCode);
    this.groupAuth.Controls.Add(this.btnGenerate);
    this.groupAuth.Controls.Add(this.checkKey);
    this.groupAuth.Location = new System.Drawing.Point(385, 45);
    this.groupAuth.Name = "groupAuth";
    this.groupAuth.Size = new System.Drawing.Size(360, 185);
    this.groupAuth.TabIndex = 2;
    this.groupAuth.Text = "Данные для авторизации";
    // 
    // labelLogin
    // 
    this.labelLogin.AutoSize = true;
    this.labelLogin.Location = new System.Drawing.Point(10, 28);
    this.labelLogin.Name = "labelLogin";
    this.labelLogin.Text = "Логин:";
    // 
    // boxLogin
    // 
    this.boxLogin.Location = new System.Drawing.Point(120, 25);
    this.boxLogin.Name = "boxLogin";
    this.boxLogin.Size = new System.Drawing.Size(225, 20);
    this.boxLogin.TabIndex = 0;
    // 
    // labelPassword
    // 
    this.labelPassword.AutoSize = true;
    this.labelPassword.Location = new System.Drawing.Point(10, 58);
    this.labelPassword.Name = "labelPassword";
    this.labelPassword.Text = "Пароль:";
    // 
    // boxPassword
    // 
    this.boxPassword.Location = new System.Drawing.Point(120, 55);
    this.boxPassword.Name = "boxPassword";
    this.boxPassword.Size = new System.Drawing.Size(225, 20);
    this.boxPassword.TabIndex = 1;
    this.boxPassword.UseSystemPasswordChar = true;
    // 
    // labelRepeat
    // 
    this.labelRepeat.AutoSize = true;
    this.labelRepeat.Location = new System.Drawing.Point(10, 88);
    this.labelRepeat.Name = "labelRepeat";
    this.labelRepeat.Text = "Повтор пароля:";
    // 
    // boxRepeat
    // 
    this.boxRepeat.Location = new System.Drawing.Point(120, 85);
    this.boxRepeat.Name = "boxRepeat";
    this.boxRepeat.Size = new System.Drawing.Size(225, 20);
    this.boxRepeat.TabIndex = 2;
    this.boxRepeat.UseSystemPasswordChar = true;
    // 
    // labelCode
    // 
    this.labelCode.AutoSize = true;
    this.labelCode.Location = new System.Drawing.Point(10, 118);
    this.labelCode.Name = "labelCode";
    this.labelCode.Text = "Код авторизации:";
    // 
    // boxCode
    // 
    this.boxCode.Location = new System.Drawing.Point(120, 115);
    this.boxCode.Name = "boxCode";
    this.boxCode.Size = new System.Drawing.Size(110, 20);
    this.boxCode.TabIndex = 3;
    // 
    // btnGenerate
    // 
    this.btnGenerate.Location = new System.Drawing.Point(235, 113);
    this.btnGenerate.Name = "btnGenerate";
    this.btnGenerate.Size = new System.Drawing.Size(110, 24);
    this.btnGenerate.TabIndex = 4;
    this.btnGenerate.Text = "Сгенерировать";
    this.btnGenerate.UseVisualStyleBackColor = true;
    this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
    // 
    // checkKey
    // 
    this.checkKey.Location = new System.Drawing.Point(13, 148);
    this.checkKey.Name = "checkKey";
    this.checkKey.Size = new System.Drawing.Size(330, 20);
    this.checkKey.TabIndex = 5;
    this.checkKey.Text = "Создать файл-ключ";
    this.checkKey.Checked = true;
    this.checkKey.UseVisualStyleBackColor = true;
    // 
    // groupEmployee
    // 
    this.groupEmployee.Controls.Add(this.labelPosition);
    this.groupEmployee.Controls.Add(this.comboPosition);
    this.groupEmployee.Controls.Add(this.labelFaculty);
    this.groupEmployee.Controls.Add(this.comboFaculty);
    this.groupEmployee.Controls.Add(this.labelStatus);
    this.groupEmployee.Controls.Add(this.comboStatus);
    this.groupEmployee.Location = new System.Drawing.Point(12, 240);
    this.groupEmployee.Name = "groupEmployee";
    this.groupEmployee.Size = new System.Drawing.Size(733, 95);
    this.groupEmployee.TabIndex = 3;
    this.groupEmployee.Text = "Данные сотрудника";
    // 
    // labelPosition
    // 
    this.labelPosition.AutoSize = true;
    this.labelPosition.Location = new System.Drawing.Point(10, 28);
    this.labelPosition.Name = "labelPosition";
    this.labelPosition.Text = "Должность:";
    // 
    // comboPosition
    // 
    this.comboPosition.Location = new System.Drawing.Point(120, 25);
    this.comboPosition.Name = "comboPosition";
    this.comboPosition.Size = new System.Drawing.Size(225, 20);
    this.comboPosition.TabIndex = 0;
    this.comboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    // 
    // labelFaculty
    // 
    this.labelFaculty.AutoSize = true;
    this.labelFaculty.Location = new System.Drawing.Point(10, 58);
    this.labelFaculty.Name = "labelFaculty";
    this.labelFaculty.Text = "Факультет:";
    // 
    // comboFaculty
    // 
    this.comboFaculty.Location = new System.Drawing.Point(120, 55);
    this.comboFaculty.Name = "comboFaculty";
    this.comboFaculty.Size = new System.Drawing.Size(225, 20);
    this.comboFaculty.TabIndex = 1;
    this.comboFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    // 
    // labelStatus
    // 
    this.labelStatus.AutoSize = true;
    this.labelStatus.Location = new System.Drawing.Point(383, 28);
    this.labelStatus.Name = "labelStatus";
    this.labelStatus.Text = "Статус:";
    // 
    // comboStatus
    // 
    this.comboStatus.Location = new System.Drawing.Point(493, 25);
    this.comboStatus.Name = "comboStatus";
    this.comboStatus.Size = new System.Drawing.Size(150, 20);
    this.comboStatus.TabIndex = 2;
    this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    // 
    // groupAbiturient
    // 
    this.groupAbiturient.Controls.Add(this.labelSpeciality);
    this.groupAbiturient.Controls.Add(this.comboSpeciality);
    this.groupAbiturient.Controls.Add(this.labelExamScore);
    this.groupAbiturient.Controls.Add(this.boxExamScore);
    this.groupAbiturient.Controls.Add(this.labelDocuments);
    this.groupAbiturient.Controls.Add(this.comboDocuments);
    this.groupAbiturient.Location = new System.Drawing.Point(12, 240);
    this.groupAbiturient.Name = "groupAbiturient";
    this.groupAbiturient.Size = new System.Drawing.Size(733, 95);
    this.groupAbiturient.TabIndex = 4;
    this.groupAbiturient.Text = "Данные абитуриента";
    // 
    // labelSpeciality
    // 
    this.labelSpeciality.AutoSize = true;
    this.labelSpeciality.Location = new System.Drawing.Point(10, 28);
    this.labelSpeciality.Name = "labelSpeciality";
    this.labelSpeciality.Text = "Направление:";
    // 
    // comboSpeciality
    // 
    this.comboSpeciality.Location = new System.Drawing.Point(120, 25);
    this.comboSpeciality.Name = "comboSpeciality";
    this.comboSpeciality.Size = new System.Drawing.Size(300, 20);
    this.comboSpeciality.TabIndex = 0;
    this.comboSpeciality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    // 
    // labelExamScore
    // 
    this.labelExamScore.AutoSize = true;
    this.labelExamScore.Location = new System.Drawing.Point(10, 58);
    this.labelExamScore.Name = "labelExamScore";
    this.labelExamScore.Text = "Сумма баллов ЕГЭ:";
    // 
    // boxExamScore
    // 
    this.boxExamScore.Location = new System.Drawing.Point(120, 55);
    this.boxExamScore.Name = "boxExamScore";
    this.boxExamScore.Size = new System.Drawing.Size(80, 20);
    this.boxExamScore.TabIndex = 1;
    // 
    // labelDocuments
    // 
    this.labelDocuments.AutoSize = true;
    this.labelDocuments.Location = new System.Drawing.Point(450, 28);
    this.labelDocuments.Name = "labelDocuments";
    this.labelDocuments.Text = "Документы:";
    // 
    // comboDocuments
    // 
    this.comboDocuments.Location = new System.Drawing.Point(530, 25);
    this.comboDocuments.Name = "comboDocuments";
    this.comboDocuments.Size = new System.Drawing.Size(150, 20);
    this.comboDocuments.TabIndex = 2;
    this.comboDocuments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    // 
    // btnRegister
    // 
    this.btnRegister.Location = new System.Drawing.Point(12, 345);
    this.btnRegister.Name = "btnRegister";
    this.btnRegister.Size = new System.Drawing.Size(140, 27);
    this.btnRegister.TabIndex = 5;
    this.btnRegister.Text = "Зарегистрировать";
    this.btnRegister.UseVisualStyleBackColor = true;
    this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
    // 
    // btnClear
    // 
    this.btnClear.Location = new System.Drawing.Point(160, 345);
    this.btnClear.Name = "btnClear";
    this.btnClear.Size = new System.Drawing.Size(100, 27);
    this.btnClear.TabIndex = 6;
    this.btnClear.Text = "Очистить";
    this.btnClear.UseVisualStyleBackColor = true;
    this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
    // 
    // RegistrationPage
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.AutoScroll = true;
    this.Controls.Add(this.labelKind);
    this.Controls.Add(this.comboKind);
    this.Controls.Add(this.groupPerson);
    this.Controls.Add(this.groupAuth);
    this.Controls.Add(this.groupEmployee);
    this.Controls.Add(this.groupAbiturient);
    this.Controls.Add(this.btnRegister);
    this.Controls.Add(this.btnClear);
    this.Name = "RegistrationPage";
    this.Size = new System.Drawing.Size(760, 385);
    this.groupPerson.ResumeLayout(false);
    this.groupPerson.PerformLayout();
    this.groupAuth.ResumeLayout(false);
    this.groupAuth.PerformLayout();
    this.groupEmployee.ResumeLayout(false);
    this.groupEmployee.PerformLayout();
    this.groupAbiturient.ResumeLayout(false);
    this.groupAbiturient.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }

  #endregion
}
}
