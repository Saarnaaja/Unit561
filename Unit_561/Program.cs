using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_561
{
    internal class Program
    {
        const string INPUT_CHAR = ">: ";
        static void Main(string[] args)
        {
            ShowUser(EnterUser());
            Console.ReadLine();
        }

        static (string FirstName, string LastName, int Age, string[] Pets, string[] Colors) EnterUser()
        {
            (string FirstName, string LastName, int Age, string[] Pets, string[] Colors) user = ("", "", 0, new string[0], new string[0]);

            Console.WriteLine("Введите ваше имя:");
            user.FirstName = InputString();

            Console.WriteLine("Введите вашу фамилию:");
            user.LastName = InputString();

            Console.WriteLine("Введите ваш возраст цифрами:");
            user.Age = InputNum(1);

            Console.WriteLine("У вас есть питомцы? (y\\n)");
            Console.Write(INPUT_CHAR);
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Сколько у вас питомцев?");
                int petsCount = InputNum(1);
                Console.WriteLine("Введите их клички:");
                user.Pets = FillArray(petsCount);
            }

            Console.WriteLine("Сколько у вас любимых цветов?");
            int colorsCount = InputNum(0);
            if (colorsCount != 0)
            {
                Console.WriteLine("Введите их названия:");
                user.Colors = FillArray(colorsCount);
            }
            return user;
        }

        static void ShowUser((string FirstName, string LastName, int Age, string[] Pets, string[] Colors) user)
        {
            Console.WriteLine($"Ваше имя: {user.FirstName}");
            Console.WriteLine($"Ваша фамилия: {user.LastName}");
            Console.WriteLine($"Ваш возраст: {user.Age}");
            Console.WriteLine($"Питомцы: {ArrayToString(user.Pets)}");
            Console.WriteLine($"Любимые цвета: {ArrayToString(user.Colors)}");
        }

        /// <summary>
        /// Заполнение массива строк указанной длинны с клавиатуры.
        /// </summary>
        /// <param name="length">Длинна массива.</param>
        /// <returns></returns>
        static string[] FillArray(int length)
        {
            string[] array = new string[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write(INPUT_CHAR);
                array[i] = Console.ReadLine();
            }
            return array;
        }

        /// <summary>
        /// Обработчик корректного ввода числа с консоли.
        /// </summary>
        /// <param name="minValue">Минимальное значение которое должно быть введено.</param>
        /// <returns></returns>
        static int InputNum(int minValue)
        {
            int value;
            while (true)
            {
                Console.Write(INPUT_CHAR);
                if (CheckNumber(Console.ReadLine(), out value, minValue)) break;
            }
            return value;
        }

        /// <summary>
        /// Обработчик корректного ввода текста (буквы и пробелы) с консоли.
        /// </summary>
        /// <returns></returns>
        static string InputString()
        {
            string value;
            while (true)
            {
                Console.Write(INPUT_CHAR);
                value = Console.ReadLine();
                if (CheckCharLine(value)) break;
            }
            return value;
        }

        /// <summary>
        /// Преобразование строки в число.
        /// </summary>
        /// <param name="input">Проверяемая строка.</param>
        /// <param name="value">Полученное значение.</param>
        /// <param name="minValue">Минимальное значение.</param>
        /// <returns>True - если преобразование успешно и значение >= минимального.</returns>
        static bool CheckNumber(string input, out int value, int minValue)
        {
            if (int.TryParse(input, out int tryValue))
            {
                if (tryValue >= minValue)
                {
                    value = tryValue;
                    return true;
                }
            }
            value = 0;
            return false;
        }

        /// <summary>
        /// Проверка строки на ввод только букв и пробела.
        /// </summary>
        /// <param name="line">Проверяемая строка.</param>
        /// <returns></returns>
        static bool CheckCharLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return false;
            foreach (var ch in line)
            {
                if (!char.IsLetter(ch) && ch != ' ')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Сборка массива в строку.
        /// </summary>
        /// <param name="array">Массив.</param>
        /// <returns>Значения массива через ",". При пустом массиве "Нет".</returns>
        static string ArrayToString(string[] array)
        {
            return array.Length == 0 ? "Нет" : string.Join(", ", array);
        }
    }
}
