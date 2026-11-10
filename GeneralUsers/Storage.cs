using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeneralUsers {
// Работа с папками пользователей (employees, abiturients, guests).
// Каждый пользователь хранится в отдельном файле [логин].txt,
// каждая строка файла имеет вид "Поле: значение".
public static class Storage {
  public const string FileExtension = ".txt";
  private const string Separator = ": ";

  // Папки пользователей находятся рядом с исполняемым файлом программы.
  public static string GetFolder(string folderName) {
    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);
  }

  public static string GetFilePath(string folderName, string login) {
    return Path.Combine(GetFolder(folderName), login + FileExtension);
  }

  public static string[] GetFiles(string folderName) {
    string folder = GetFolder(folderName);

    if (!Directory.Exists(folder)) {
      return new string[0];
    }

    return Directory.GetFiles(folder, "*" + FileExtension);
  }

  public static void Write(string path, Dictionary<string, string> record) {
    Directory.CreateDirectory(Path.GetDirectoryName(path));

    FileStream file = new FileStream(
      path,
      FileMode.CreateNew,
      FileAccess.Write
    );

    StreamWriter writer = new StreamWriter(file, Encoding.UTF8);

    try {
      foreach (KeyValuePair<string, string> pair in record) {
        writer.WriteLine(pair.Key + Separator + pair.Value);
      }
    }
    finally {
      writer.Close();
    }
  }

  public static Dictionary<string, string> Read(string path) {
    Dictionary<string, string> record = new Dictionary<string, string>();

    foreach (string line in File.ReadAllLines(path, Encoding.UTF8)) {
      int index = line.IndexOf(Separator, StringComparison.Ordinal);

      if (index <= 0) {
        continue;
      }

      record[line.Substring(0, index)] =
        line.Substring(index + Separator.Length);
    }

    return record;
  }
}
}
