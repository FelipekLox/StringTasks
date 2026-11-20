using System;
using System.Collections.Generic;

namespace StringTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string csvLine = "\"Smith, John\",42,\"New York, NY\"";

            Console.WriteLine("=== Задание 4: Парсер CSV с кавычками ===");
            Console.WriteLine($"Исходная строка: {csvLine}\n");

            List<string> fields = CsvParser.ParseLine(csvLine);
            Console.WriteLine($"Распознано полей: {fields.Count}");
            for (int i = 0; i < fields.Count; i++)
            {
                Console.WriteLine($"  Поле [{i + 1}]: {fields[i]}");
            }

            string rebuilt = CsvParser.BuildLine(fields);
            Console.WriteLine($"\nОбратная сборка: {rebuilt}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}