using System;
using System.Collections.Generic;
using System.Text;

namespace StringTasks
{
    public class CsvParser
    {
        // Посимвольный разбор CSV-строки (конечный автомат)
        public static List<string> ParseLine(string line)
        {
            var result = new List<string>();
            if (line == null)
                return result;

            var currentField = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (inQuotes)
                {
                    if (c == '"')
                    {
                        // Проверка на экранированную кавычку "" внутри поля
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            currentField.Append('"');
                            i++; // Пропускаем вторую кавычку
                        }
                        else
                        {
                            inQuotes = false; // Выходим из режима кавычек
                        }
                    }
                    else
                    {
                        currentField.Append(c);
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else if (c == ',')
                    {
                        result.Add(currentField.ToString());
                        currentField.Clear();
                    }
                    else
                    {
                        currentField.Append(c);
                    }
                }
            }

            // Добавляем последнее поле после цикла
            result.Add(currentField.ToString());
            return result;
        }

        // Дополнительно: обратная сборка списка полей в CSV-строку с экранированием
        public static string BuildLine(IEnumerable<string> fields)
        {
            var encodedFields = new List<string>();

            foreach (var field in fields)
            {
                string val = field ?? string.Empty;
                // Если поле содержит запятую, кавычку или перенос строки — оборачиваем в кавычки
                if (val.Contains(",") || val.Contains("\"") || val.Contains("\n"))
                {
                    val = "\"" + val.Replace("\"", "\"\"") + "\"";
                }
                encodedFields.Add(val);
            }

            return string.Join(",", encodedFields);
        }
    }
}