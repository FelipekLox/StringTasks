using System;
using System.Linq;

namespace StringTasks
{
    public class TextAnalyzer
    {
        public static void Analyze(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Текст пуст.");
                return;
            }

            // 1. Количество символов (с пробелами и без)
            int totalChars = text.Length;
            int charsWithoutSpaces = text.Count(c => !char.IsWhiteSpace(c));

            // 2. Количество слов (разделители — пробелы, запятые, точки и переносы строк)
            char[] wordDelimiters = { ' ', ',', '.', '\n', '\r', '\t' };
            string[] words = text.Split(wordDelimiters, StringSplitOptions.RemoveEmptyEntries);

            // 3. Количество предложений (разделители — . ! ?)
            char[] sentenceDelimiters = { '.', '!', '?' };
            string[] sentences = text.Split(sentenceDelimiters, StringSplitOptions.RemoveEmptyEntries)
                                     .Where(s => !string.IsNullOrWhiteSpace(s))
                                     .ToArray();

            // 4. Самое длинное и самое короткое слово
            string longestWord = words.OrderByDescending(w => w.Length).FirstOrDefault() ?? "";
            string shortestWord = words.OrderBy(w => w.Length).FirstOrDefault() ?? "";

            // 5. Топ-5 слов по частоте (без учёта регистра)
            var topWords = words
                .Select(w => w.Trim().ToLower())
                .GroupBy(w => w)
                .Select(g => new { Word = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Word)
                .Take(5);

            // Вывод статистики
            Console.WriteLine("=== Задание 1: Анализатор текста ===");
            Console.WriteLine($"Символов (с пробелами): {totalChars}");
            Console.WriteLine($"Символов (без пробелов): {charsWithoutSpaces}");
            Console.WriteLine($"Количество слов: {words.Length}");
            Console.WriteLine($"Количество предложений: {sentences.Length}");
            Console.WriteLine($"Самое длинное слово: {longestWord} ({longestWord.Length})");
            Console.WriteLine($"Самое короткое слово: {shortestWord} ({shortestWord.Length})");

            Console.WriteLine("\nТоп-5 частых слов:");
            foreach (var item in topWords)
            {
                Console.WriteLine($"- {item.Word}: {item.Count}");
            }
        }
    }
}