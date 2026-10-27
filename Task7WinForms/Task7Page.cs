using System;
using System.Windows.Forms;
using GeneralUsers;
using Task7;
using Task8WinForms;

namespace Task7WinForms {
// Форма авторизации сотрудника, абитуриента и гостя.
// После успешной авторизации открывается окно с данными пользователя.
public partial class Task7Page : UserControl {
  private User _user;
  private UserForm _userForm;

  public Task7Page() {
    InitializeComponent();

    comboKind.Items.AddRange(Functions.KindNames);
    comboKind.SelectedIndex = 0;

    UpdateDataFields();
  }

  private UserKind SelectedKind {
    get { return (UserKind)comboKind.SelectedIndex; }
  }

  // Показывает поля ввода для выбранного способа авторизации.
  private void UpdateDataFields() {
    bool byPassword = radioPassword.Checked;
    bool byCode = radioCode.Checked;
    bool byKey = radioKey.Checked;

    labelLogin.Visible = boxLogin.Visible = byPassword;
    labelPassword.Visible = boxPassword.Visible = byPassword;
    labelCode.Visible = boxCode.Visible = byCode;
    labelKey.Visible = boxKeyPath.Visible = btnBrowse.Visible = byKey;
  }

  private void radio_CheckedChanged(object sender, EventArgs e) {
    UpdateDataFields();
  }

  private void btnBrowse_Click(object sender, EventArgs e) {
    if (openKeyDialog.ShowDialog() == DialogResult.OK) {
      boxKeyPath.Text = openKeyDialog.FileName;
    }
  }

  private void btnLogin_Click(object sender, EventArgs e) {
    User user;
    string message;

    try {
      if (radioPassword.Checked) {
        user = Functions.ByPassword(
          SelectedKind,
          boxLogin.Text,
          boxPassword.Text,
          out message
        );
      }
      else if (radioCode.Checked) {
        user = Functions.ByCode(SelectedKind, boxCode.Text, out message);
      }
      else {
        user = Functions.ByKey(SelectedKind, boxKeyPath.Text, out message);
      }
    }
    catch (Exception ex) {
      MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (user == null) {
      labelResult.Text = "Авторизация не выполнена. " + message;
      MessageBox.Show(message, "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    // Объект пользователя сохраняется только после успешной авторизации.
    Logout();
    _user = user;
    labelResult.Text = message;
    boxPassword.Clear();

    btnOpen.Enabled = true;
    btnLogout.Enabled = true;

    OpenUserForm();
  }

  private void btnOpen_Click(object sender, EventArgs e) {
    OpenUserForm();
  }

  private void btnLogout_Click(object sender, EventArgs e) {
    Logout();
    labelResult.Text = "Вы вышли из системы.";
  }

  // Открывает окно пользователя. Если окно уже открыто - делает его активным.
  private void OpenUserForm() {
    if (_user == null) {
      return;
    }

    if (_userForm == null || _userForm.IsDisposed) {
      _userForm = new UserForm(_user);
      _userForm.Show();
    }
    else {
      _userForm.Activate();
    }
  }

  // Закрывает окно пользователя и сбрасывает текущего пользователя.
  private void Logout() {
    if (_userForm != null && !_userForm.IsDisposed) {
      _userForm.Close();
    }

    _userForm = null;
    _user = null;
    btnOpen.Enabled = false;
    btnLogout.Enabled = false;
  }
}
}
