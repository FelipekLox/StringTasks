using System;

namespace StringTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalText = "Hello, World! 2026 - C# Caesar Cipher (Test: xyz / XYZ).";
            int shift = 3;

            string encrypted = CaesarCipher.Encrypt(originalText, shift);
            string decrypted = CaesarCipher.Decrypt(encrypted, shift);

            Console.WriteLine("=== Задание 3: Шифр Цезаря ===");
            Console.WriteLine($"Исходный текст:      {originalText}");
            Console.WriteLine($"Зашифрованный (+{shift}):  {encrypted}");
            Console.WriteLine($"Расшифрованный (-{shift}): {decrypted}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}