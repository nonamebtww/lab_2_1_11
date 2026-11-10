using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GeneralUsers;

namespace Task8WinForms {
// Окно, которое открывается после успешной авторизации
// и отображает все поля пользователя.
public partial class UserForm : Form {
  public UserForm(User user) {
    InitializeComponent();

    Text = "Пользователь: " + user.Login;
    labelGreeting.Text = user.GetGreeting();

    foreach (KeyValuePair<string, string> field in user.GetFields()) {
      listFields.Items.Add(new ListViewItem(new[] { field.Key, field.Value }));
    }
  }

  private void btnClose_Click(object sender, EventArgs e) {
    Close();
  }
}
}
