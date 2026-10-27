using System;
using System.Windows.Forms;
using AppWinUi.Pages;
using Task7WinForms;

namespace AppWinUi {
public partial class Main : Form {
  public Main() {
    InitializeComponent();
    
    box_page.Items.AddRange(new object[] {
      "Регистрация",
      "Задания 7, 8 - авторизация"
    });
    
    ShowPage(new HomePage());
  }
  
  private void box_page_SelectedIndexChanged(object sender, EventArgs e) {
    var box = (ComboBox)sender;
    
    switch (box.SelectedIndex) {
      case 0:
        ShowPage(new RegistrationPage());
        break;
      case 1:
        ShowPage(new Task7Page());
        break;
    }
  }

  #region Helpers

  private void ShowPage(UserControl page) {
    body.Controls.Clear();
    body.Controls.Add(page);
    page.Dock = DockStyle.Fill;
  }

  #endregion
}
}
