using System;

namespace StringTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sampleText = @"Привет, мир! Это тестовый текст для анализатора.
Текст содержит несколько предложений, слова и знаки препинания.
Анализатор посчитает слова, символы и выведет топ слов!";

            TextAnalyzer.Analyze(sampleText);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
