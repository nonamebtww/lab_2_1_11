using System;
using GeneralConsole;

namespace AppConsole {
  internal class Program {
    private static void Main(string[] args) {
      while (true) {
        Console.Clear();

        Console.Write(
          "Меню:\n" +
          "1. Регистрация пользователя\n" +
          "2. Задания 7, 8 - авторизация и окно пользователя\n" +
          "0. Выход\n" +
          "Введите действие: "
        );

        switch (Console.ReadLine()) {
            case "1":
              Console.Clear();
              Task7Console.Ui.RegistrationUi();
              Helpers.Pause();
              break;
            case "2":
              Console.Clear();
              Task7Console.Ui.Task7Ui();
              break;
            case "0":
              return;
            default:
              Console.WriteLine("Введено неверное значение!");
              Helpers.Pause();
              break;
        }
      }
    }
  }
}
