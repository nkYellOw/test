using Mono.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace scrape_getfpv_com
{
  static class Func
  {
    /// <summary>
    /// Преобразует словарь в строку параметров для интернет-запроса
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dictionary">Словарь с параметрами</param>
    /// <returns>Строка параметров для интернет-запроса</returns>
    public static string DictionaryToUrlParam<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
    {
      return string.Join("&", dictionary.Select(kv => kv.Key + "=" + kv.Value).ToArray());
    }

    /// <summary>
    /// Метод выполняющий удаление, либо замену недопустимых символов в названии файла (Windows)
    /// </summary>
    /// <param name="fileName">Название файла</param>
    /// <param name="newSymbol">Новый символ, вместо недопустимых</param>
    /// <returns></returns>
    public static string WindowsFileNameClear(string fileName, string newSymbol = null)
    {
      List<string> symbolList = new List<string>
      {
        "?",
        "/",
        "\\",
        "*",
        "\"",
        "<",
        ">",
        "|",
        ":",
      };

      for (int i = 0; i < symbolList.Count; i++)
      {
        if (newSymbol != null)
        {
          fileName = fileName.Replace(symbolList[i], newSymbol);
        }
        else
        {
          fileName = fileName.Replace(symbolList[i], "");
        }
      }

      return fileName;
    }

    /// <summary>
    /// Метод выполняющий запись свойств объектов в файл csv
    /// </summary>
    /// <typeparam name="T">Класс объекта</typeparam>
    /// <param name="obj">Объект для записи</param>
    /// <param name="filePath">Путь файла для записи</param>
    /// <param name="delimiter">Разделитель свойств в csv файле</param>
    public static void SaveObjectToCsv<T>(T obj, string filePath, string delimiter = ";", Encoding encoding = null)
    {
      string line = "";

      Type myType = typeof(T);
      var myPropertyInfo = myType.GetProperties();

      // Если файл не существует, пишем заголовки в csv файле
      if (!File.Exists(filePath))
      {
        for (int i = 0; i < myPropertyInfo.Length; i++)
        {
          string name = myPropertyInfo[i].Name;
          line += "\"" + name + "\"" + delimiter;
        }

        line = line.Trim(new char[] { delimiter[0] });
        InsertToFile(filePath, line);
        line = "";
      }

      for (int i = 0; i < myPropertyInfo.Length; i++)
      {
        var value = myPropertyInfo[i].GetValue(obj, null);
        if (value != null)
        {
          line += "\"" + value.ToString().Replace("\"", "\"\"") + "\"" + delimiter;
        }
        else
        {
          line += "\"" + "\"" + delimiter;
        }
      }
      line = line.Trim(new char[] { delimiter[0] });

      InsertToFile(filePath, line, encoding);
    }

    /// <summary>
    /// Вставка (дозапись) строки в файл
    /// </summary>
    /// <param name="fileName">путь к файлу</param>
    /// <param name="line">Строка</param>
    public static void InsertToFile(string fileName, string line, Encoding encoding = null)
    {
      if (encoding != null)
      {
        using (StreamWriter sw = new StreamWriter(fileName, true, encoding))
        {
          sw.WriteLine(line);
        }
      }
      else
      {
        using (StreamWriter sw = new StreamWriter(fileName, true))
        {
          sw.WriteLine(line);
        }
      }
    }

    /// <summary>
    /// Декодирует HTML код в корректное представление
    /// (напр. строка "&#1071;&#1074;&#1083;" станет строкой "Явл"
    /// </summary>
    /// <paramref name="html">Ссылка (ref) на строку содержащую закодированный HTML</param>
    public static void HtmlDecode(ref string html)
    {
      html = HttpUtility.HtmlDecode(html);
    }

    /// <summary>
    /// Метод возвращающий кол-во процентов выполненной задачи
    /// </summary>
    /// <param name="nowIndex">Текущее состояние (Текущий положение)</param>
    /// <param name="totalCount">Количество</param>
    /// <returns></returns>
    public static int ProgressProcent(int nowIndex, int totalCount)
    {
      return nowIndex * 100 / totalCount;
    }
  }
}
