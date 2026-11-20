using System;
using System.Linq;

namespace StringTasks
{
    public class StringChecks
    {
        // Проверка на палиндром (игнорируем пробелы, знаки препинания и регистр)
        public static bool IsPalindrome(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            string cleaned = new string(text
                .Where(char.IsLetterOrDigit)
                .Select(char.ToLower)
                .ToArray());

            string reversed = new string(cleaned.Reverse().ToArray());
            return cleaned == reversed;
        }

        // Проверка, являются ли две строки анаграммами
        public static bool AreAnagrams(string first, string second)
        {
            if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(second))
                return false;

            var s1 = first.Where(char.IsLetterOrDigit).Select(char.ToLower).OrderBy(c => c);
            var s2 = second.Where(char.IsLetterOrDigit).Select(char.ToLower).OrderBy(c => c);

            return s1.SequenceEqual(s2);
        }
    }
}
