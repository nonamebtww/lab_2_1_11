using System;
using System.Collections.Generic;
using GeneralUsers;

namespace Task8Console {
public static class Ui {
  // «Окно» пользователя: выводит все поля авторизованного пользователя.
  // Окно открывается после успешной авторизации и закрывается по нажатию клавиши.
  public static void Task8Ui(User user) {
    Console.Clear();

    string title = "Окно пользователя: " + user.Role;
    string line = new string('=', 60);

    Console.WriteLine(line);
    Console.WriteLine(title);
    Console.WriteLine(line);

    foreach (KeyValuePair<string, string> field in user.GetFields()) {
      Console.WriteLine("{0,-20}{1}", field.Key + ":", field.Value);
    }

    Console.WriteLine(line);
    Console.WriteLine("Нажмите любую клавишу, чтобы закрыть окно...");
    Console.ReadKey(true);
  }
}
}
