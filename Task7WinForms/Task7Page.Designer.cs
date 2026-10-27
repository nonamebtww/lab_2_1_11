namespace Task7WinForms {
partial class Task7Page {
  private System.ComponentModel.IContainer components = null;

  private System.Windows.Forms.Label labelKind;
  private System.Windows.Forms.ComboBox comboKind;
  private System.Windows.Forms.GroupBox groupMethod;
  private System.Windows.Forms.RadioButton radioPassword;
  private System.Windows.Forms.RadioButton radioCode;
  private System.Windows.Forms.RadioButton radioKey;
  private System.Windows.Forms.GroupBox groupData;
  private System.Windows.Forms.Label labelLogin;
  private System.Windows.Forms.TextBox boxLogin;
  private System.Windows.Forms.Label labelPassword;
  private System.Windows.Forms.TextBox boxPassword;
  private System.Windows.Forms.Label labelCode;
  private System.Windows.Forms.TextBox boxCode;
  private System.Windows.Forms.Label labelKey;
  private System.Windows.Forms.TextBox boxKeyPath;
  private System.Windows.Forms.Button btnBrowse;
  private System.Windows.Forms.Button btnLogin;
  private System.Windows.Forms.Button btnOpen;
  private System.Windows.Forms.Button btnLogout;
  private System.Windows.Forms.Label labelResult;
  private System.Windows.Forms.OpenFileDialog openKeyDialog;

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
    this.groupMethod = new System.Windows.Forms.GroupBox();
    this.radioPassword = new System.Windows.Forms.RadioButton();
    this.radioCode = new System.Windows.Forms.RadioButton();
    this.radioKey = new System.Windows.Forms.RadioButton();
    this.groupData = new System.Windows.Forms.GroupBox();
    this.labelLogin = new System.Windows.Forms.Label();
    this.boxLogin = new System.Windows.Forms.TextBox();
    this.labelPassword = new System.Windows.Forms.Label();
    this.boxPassword = new System.Windows.Forms.TextBox();
    this.labelCode = new System.Windows.Forms.Label();
    this.boxCode = new System.Windows.Forms.TextBox();
    this.labelKey = new System.Windows.Forms.Label();
    this.boxKeyPath = new System.Windows.Forms.TextBox();
    this.btnBrowse = new System.Windows.Forms.Button();
    this.btnLogin = new System.Windows.Forms.Button();
    this.btnOpen = new System.Windows.Forms.Button();
    this.btnLogout = new System.Windows.Forms.Button();
    this.labelResult = new System.Windows.Forms.Label();
    this.openKeyDialog = new System.Windows.Forms.OpenFileDialog();
    this.groupMethod.SuspendLayout();
    this.groupData.SuspendLayout();
    this.openKeyDialog.Filter = "Файл-ключ (*.key)|*.key|Все файлы (*.*)|*.*";
    this.SuspendLayout();
    // 
    // labelKind
    // 
    this.labelKind.AutoSize = true;
    this.labelKind.Location = new System.Drawing.Point(12, 15);
    this.labelKind.Name = "labelKind";
    this.labelKind.Text = "Кто входит:";
    // 
    // comboKind
    // 
    this.comboKind.Location = new System.Drawing.Point(130, 12);
    this.comboKind.Name = "comboKind";
    this.comboKind.Size = new System.Drawing.Size(200, 20);
    this.comboKind.TabIndex = 0;
    this.comboKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    // 
    // groupMethod
    // 
    this.groupMethod.Controls.Add(this.radioPassword);
    this.groupMethod.Controls.Add(this.radioCode);
    this.groupMethod.Controls.Add(this.radioKey);
    this.groupMethod.Location = new System.Drawing.Point(12, 45);
    this.groupMethod.Name = "groupMethod";
    this.groupMethod.Size = new System.Drawing.Size(420, 110);
    this.groupMethod.TabIndex = 1;
    this.groupMethod.Text = "Способ авторизации";
    // 
    // radioPassword
    // 
    this.radioPassword.Location = new System.Drawing.Point(13, 22);
    this.radioPassword.Name = "radioPassword";
    this.radioPassword.Size = new System.Drawing.Size(300, 22);
    this.radioPassword.TabIndex = 0;
    this.radioPassword.Text = "Логин и пароль";
    this.radioPassword.Checked = true;
    this.radioPassword.UseVisualStyleBackColor = true;
    this.radioPassword.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
    // 
    // radioCode
    // 
    this.radioCode.Location = new System.Drawing.Point(13, 48);
    this.radioCode.Name = "radioCode";
    this.radioCode.Size = new System.Drawing.Size(300, 22);
    this.radioCode.TabIndex = 1;
    this.radioCode.Text = "Код авторизации";
    this.radioCode.UseVisualStyleBackColor = true;
    this.radioCode.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
    // 
    // radioKey
    // 
    this.radioKey.Location = new System.Drawing.Point(13, 74);
    this.radioKey.Name = "radioKey";
    this.radioKey.Size = new System.Drawing.Size(300, 22);
    this.radioKey.TabIndex = 2;
    this.radioKey.Text = "Файл-ключ";
    this.radioKey.UseVisualStyleBackColor = true;
    this.radioKey.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
    // 
    // groupData
    // 
    this.groupData.Controls.Add(this.labelLogin);
    this.groupData.Controls.Add(this.boxLogin);
    this.groupData.Controls.Add(this.labelPassword);
    this.groupData.Controls.Add(this.boxPassword);
    this.groupData.Controls.Add(this.labelCode);
    this.groupData.Controls.Add(this.boxCode);
    this.groupData.Controls.Add(this.labelKey);
    this.groupData.Controls.Add(this.boxKeyPath);
    this.groupData.Controls.Add(this.btnBrowse);
    this.groupData.Location = new System.Drawing.Point(12, 165);
    this.groupData.Name = "groupData";
    this.groupData.Size = new System.Drawing.Size(420, 115);
    this.groupData.TabIndex = 2;
    this.groupData.Text = "Данные для входа";
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
    this.boxLogin.Location = new System.Drawing.Point(130, 25);
    this.boxLogin.Name = "boxLogin";
    this.boxLogin.Size = new System.Drawing.Size(270, 20);
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
    this.boxPassword.Location = new System.Drawing.Point(130, 55);
    this.boxPassword.Name = "boxPassword";
    this.boxPassword.Size = new System.Drawing.Size(270, 20);
    this.boxPassword.TabIndex = 1;
    this.boxPassword.UseSystemPasswordChar = true;
    // 
    // labelCode
    // 
    this.labelCode.AutoSize = true;
    this.labelCode.Location = new System.Drawing.Point(10, 28);
    this.labelCode.Name = "labelCode";
    this.labelCode.Text = "Код авторизации:";
    // 
    // boxCode
    // 
    this.boxCode.Location = new System.Drawing.Point(130, 25);
    this.boxCode.Name = "boxCode";
    this.boxCode.Size = new System.Drawing.Size(120, 20);
    this.boxCode.TabIndex = 2;
    // 
    // labelKey
    // 
    this.labelKey.AutoSize = true;
    this.labelKey.Location = new System.Drawing.Point(10, 28);
    this.labelKey.Name = "labelKey";
    this.labelKey.Text = "Файл-ключ:";
    // 
    // boxKeyPath
    // 
    this.boxKeyPath.Location = new System.Drawing.Point(130, 25);
    this.boxKeyPath.Name = "boxKeyPath";
    this.boxKeyPath.Size = new System.Drawing.Size(190, 20);
    this.boxKeyPath.TabIndex = 3;
    // 
    // btnBrowse
    // 
    this.btnBrowse.Location = new System.Drawing.Point(325, 23);
    this.btnBrowse.Name = "btnBrowse";
    this.btnBrowse.Size = new System.Drawing.Size(75, 24);
    this.btnBrowse.TabIndex = 4;
    this.btnBrowse.Text = "Обзор...";
    this.btnBrowse.UseVisualStyleBackColor = true;
    this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
    // 
    // btnLogin
    // 
    this.btnLogin.Location = new System.Drawing.Point(12, 290);
    this.btnLogin.Name = "btnLogin";
    this.btnLogin.Size = new System.Drawing.Size(100, 27);
    this.btnLogin.TabIndex = 3;
    this.btnLogin.Text = "Войти";
    this.btnLogin.UseVisualStyleBackColor = true;
    this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
    // 
    // btnOpen
    // 
    this.btnOpen.Location = new System.Drawing.Point(120, 290);
    this.btnOpen.Name = "btnOpen";
    this.btnOpen.Size = new System.Drawing.Size(150, 27);
    this.btnOpen.TabIndex = 4;
    this.btnOpen.Text = "Открыть окно";
    this.btnOpen.Enabled = false;
    this.btnOpen.UseVisualStyleBackColor = true;
    this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
    // 
    // btnLogout
    // 
    this.btnLogout.Location = new System.Drawing.Point(278, 290);
    this.btnLogout.Name = "btnLogout";
    this.btnLogout.Size = new System.Drawing.Size(100, 27);
    this.btnLogout.TabIndex = 5;
    this.btnLogout.Text = "Выйти";
    this.btnLogout.Enabled = false;
    this.btnLogout.UseVisualStyleBackColor = true;
    this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
    // 
    // labelResult
    // 
    this.labelResult.Location = new System.Drawing.Point(12, 327);
    this.labelResult.Name = "labelResult";
    this.labelResult.Size = new System.Drawing.Size(720, 40);
    this.labelResult.TabIndex = 6;
    this.labelResult.Text = "";
    // 
    // Task7Page
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.AutoScroll = true;
    this.Controls.Add(this.labelKind);
    this.Controls.Add(this.comboKind);
    this.Controls.Add(this.groupMethod);
    this.Controls.Add(this.groupData);
    this.Controls.Add(this.btnLogin);
    this.Controls.Add(this.btnOpen);
    this.Controls.Add(this.btnLogout);
    this.Controls.Add(this.labelResult);
    this.Name = "Task7Page";
    this.Size = new System.Drawing.Size(760, 385);
    this.groupMethod.ResumeLayout(false);
    this.groupMethod.PerformLayout();
    this.groupData.ResumeLayout(false);
    this.groupData.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }

  #endregion
}
}
