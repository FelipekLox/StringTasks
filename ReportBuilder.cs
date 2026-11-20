using System;
using System.IO;
using System.Text;

namespace StringTasks
{
    public class Sale
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class ReportBuilder
    {
        public static string GenerateReport(Sale[] sales)
        {
            StringBuilder sb = new StringBuilder();

            // Заголовок и дата
            sb.AppendLine("=== ОТЧЁТ О ПРОДАЖАХ ===");
            sb.AppendLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}");
            sb.AppendLine(new string('-', 62));

            // Шапка таблицы (используем PadRight и PadLeft для выравнивания)
            sb.Append("Товар".PadRight(25));
            sb.Append("Кол-во".PadLeft(10));
            sb.Append("Цена".PadLeft(12));
            sb.AppendLine("Сумма".PadLeft(15));
            sb.AppendLine(new string('-', 62));

            decimal grandTotal = 0;

            // Строки с товарами
            foreach (var sale in sales)
            {
                decimal rowTotal = sale.Quantity * sale.Price;
                grandTotal += rowTotal;

                sb.Append(sale.Product.PadRight(25));
                sb.Append(sale.Quantity.ToString().PadLeft(10));
                sb.Append(sale.Price.ToString("F2").PadLeft(12));
                sb.AppendLine(rowTotal.ToString("F2").PadLeft(15));
            }

            // Общий итог
            sb.AppendLine(new string('-', 62));
            sb.Append("ОБЩИЙ ИТОГ:".PadRight(47));
            sb.AppendLine(grandTotal.ToString("F2").PadLeft(15));

            return sb.ToString();
        }

        // Дополнительное задание: сохранение отчёта в файл
        public static void SaveToFile(string reportText, string filePath)
        {
            File.WriteAllText(filePath, reportText, Encoding.UTF8);
        }
    }
}