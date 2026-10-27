using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralConsole {
public class Helpers {
  public static int ReadInt(string message) {
    while (true) {
      Console.Write(message);

      if (int.TryParse(
            Console.ReadLine(),
            out var result
          )) {
        return result;
      }

      Console.WriteLine(
        "Введено неверное значение!"
      );
    }
  }

  public static int ReadPositiveInt(string message) {
    while (true) {
      int result = ReadInt(message);

      if (result > 0) {
        return result;
      }

      Console.WriteLine(
        "Значение должно быть больше нуля!"
      );
    }
  }

  // Считывает непустую строку.
  public static string ReadString(string message) {
    while (true) {
      Console.Write(message);

      string result = Console.ReadLine();

      if (!string.IsNullOrWhiteSpace(result)) {
        return result.Trim();
      }

      Console.WriteLine(
        "Строка не должна быть пустой!"
      );
    }
  }

  // Считывает многострочный текст.
  // Ввод заканчивается пустой строкой.
  public static string ReadText(string message) {
    Console.WriteLine(message);
    Console.WriteLine("(для окончания ввода введите пустую строку)");

    List<string> lines = new List<string>();

    while (true) {
      string line = Console.ReadLine();

      if (string.IsNullOrEmpty(line)) {
        break;
      }

      lines.Add(line);
    }

    return string.Join(Environment.NewLine, lines);
  }

  // Выводит нумерованный список и возвращает индекс выбранного элемента.
  public static int ReadChoice(string message, string[] items) {
    Console.WriteLine(message);

    for (int i = 0; i < items.Length; i++) {
      Console.WriteLine("  {0}. {1}", i + 1, items[i]);
    }

    while (true) {
      int number = ReadInt("Выберите номер: ");

      if (number >= 1 && number <= items.Length) {
        return number - 1;
      }

      Console.WriteLine(
        "Номер должен быть от 1 до {0}!",
        items.Length
      );
    }
  }

  // Считывает пароль, не показывая вводимые символы.
  public static string ReadPassword(string message) {
    Console.Write(message);

    StringBuilder result = new StringBuilder();

    while (true) {
      ConsoleKeyInfo key = Console.ReadKey(true);

      if (key.Key == ConsoleKey.Enter) {
        Console.WriteLine();
        return result.ToString();
      }

      if (key.Key == ConsoleKey.Backspace) {
        if (result.Length > 0) {
          result.Remove(result.Length - 1, 1);
          Console.Write("\b \b");
        }

        continue;
      }

      if (!char.IsControl(key.KeyChar)) {
        result.Append(key.KeyChar);
        Console.Write('*');
      }
    }
  }

  // Повторяет ввод, пока setter (например, свойство объекта)
  // не примет значение без исключения.
  public static void ReadValid(
    string message,
    Action<string> setter,
    bool hidden = false
  ) {
    while (true) {
      string input = hidden
        ? ReadPassword(message)
        : ReadLine(message);

      try {
        setter(input);
        return;
      }
      catch (ArgumentException ex) {
        Console.WriteLine(ex.Message);
      }
      catch (FormatException ex) {
        Console.WriteLine(ex.Message);
      }
    }
  }

  // Считывает строку (может быть пустой).
  public static string ReadLine(string message) {
    Console.Write(message);
    return Console.ReadLine() ?? string.Empty;
  }

  public static void Pause() {
    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
    Console.ReadKey(true);
  }
}
}
