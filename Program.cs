using System;
using System.Collections.Generic;

namespace StringTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Практическая работа: Обработка строк (C#) ===");
                Console.WriteLine("1. Анализатор текста");
                Console.WriteLine("2. Генератор отчёта (StringBuilder)");
                Console.WriteLine("3. Шифр Цезаря");
                Console.WriteLine("4. Парсер CSV с кавычками");
                Console.WriteLine("5. Проверка палиндромов и анаграмм");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите задание: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        string sampleText = @"Привет, мир! Это тестовый текст для анализатора.
Текст содержит несколько предложений, слова и знаки препинания.
Анализатор посчитает слова, символы и выведет топ слов!";
                        TextAnalyzer.Analyze(sampleText);
                        break;

                    case "2":
                        Sale[] sales = new Sale[]
                        {
                            new Sale { Product = "Ноутбук", Quantity = 2, Price = 55000.00m },
                            new Sale { Product = "Беспроводная мышь", Quantity = 5, Price = 1250.50m },
                            new Sale { Product = "Механическая клавиатура", Quantity = 3, Price = 4800.00m }
                        };
                        string report = ReportBuilder.GenerateReport(sales);
                        Console.WriteLine(report);
                        ReportBuilder.SaveToFile(report, "sales_report.txt");
                        Console.WriteLine("Отчёт сохранён в sales_report.txt");
                        break;

                    case "3":
                        string original = "Hello, World! 2026 - C# Caesar Cipher.";
                        string encrypted = CaesarCipher.Encrypt(original, 3);
                        Console.WriteLine($"Исходный:       {original}");
                        Console.WriteLine($"Зашифрованный:  {encrypted}");
                        Console.WriteLine($"Расшифрованный: {CaesarCipher.Decrypt(encrypted, 3)}");
                        break;

                    case "4":
                        string csvLine = "\"Smith, John\",42,\"New York, NY\"";
                        List<string> fields = CsvParser.ParseLine(csvLine);
                        Console.WriteLine($"Строка: {csvLine}");
                        for (int i = 0; i < fields.Count; i++)
                            Console.WriteLine($"Поле [{i + 1}]: {fields[i]}");
                        Console.WriteLine($"Сборка: {CsvParser.BuildLine(fields)}");
                        break;

                    case "5":
                        string phrase = "А роза упала на лапу Азора";
                        Console.WriteLine($"Фраза: \"{phrase}\" -> Палиндром: {StringChecks.IsPalindrome(phrase)}");
                        string w1 = "Лунь", w2 = "Нуль";
                        Console.WriteLine($"Слова: \"{w1}\" и \"{w2}\" -> Анаграммы: {StringChecks.AreAnagrams(w1, w2)}");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }
    }
}