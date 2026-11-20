using System;

namespace StringTasks
{
    public class CaesarCipher
    {
        public static string Encrypt(string text, int shift)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            char[] buffer = text.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                // Обрабатываем только буквы латинского алфавита
                if ((letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z'))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    // Формула с ((...) % 26 + 26) % 26 корректно работает даже с отрицательным сдвигом
                    int shifted = (((letter - offset + shift) % 26) + 26) % 26;
                    buffer[i] = (char)(offset + shifted);
                }
            }

            return new string(buffer);
        }

        public static string Decrypt(string text, int shift)
        {
            // Дешифрование — это шифрование с обратным сдвигом
            return Encrypt(text, -shift);
        }
    }
}