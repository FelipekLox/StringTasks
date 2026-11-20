using System;

namespace StringTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sale[] sales = new Sale[]
            {
                new Sale { Product = "Ноутбук", Quantity = 2, Price = 55000.00m },
                new Sale { Product = "Беспроводная мышь", Quantity = 5, Price = 1250.50m },
                new Sale { Product = "Механическая клавиатура", Quantity = 3, Price = 4800.00m },
                new Sale { Product = "Монитор 27\"", Quantity = 1, Price = 24990.00m }
            };

            string report = ReportBuilder.GenerateReport(sales);
            Console.WriteLine(report);

            string fileName = "sales_report.txt";
            ReportBuilder.SaveToFile(report, fileName);
            Console.WriteLine($"Отчёт успешно сохранён в файл: {fileName}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}