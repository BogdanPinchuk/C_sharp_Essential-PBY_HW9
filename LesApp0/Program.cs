using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        /// <summary>
        /// Делегат
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        delegate double DelAverage(int a, int b, int c);

        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // випадкові числа
            Random rnd = new Random();

            // випадкові цілі числа (великі числа погіршують читабельність)
            #region Створення цілих чисел
            int[] abc = new int[]
                {
                rnd.Next(sbyte.MinValue, sbyte.MaxValue),
                rnd.Next(sbyte.MinValue, sbyte.MaxValue),
                rnd.Next(sbyte.MinValue, sbyte.MaxValue)
                };

            // виведення на екран
            Console.WriteLine("\nЗгенеровані випадкові цілі числа:\n");
            Console.WriteLine($"\tA = {abc[0]:N0}");
            Console.WriteLine($"\tB = {abc[1]:N0}");
            Console.WriteLine($"\tC = {abc[2]:N0}");
            #endregion

            #region 1. Спосіб. Через статичний метод і делегат
#if false
            // створення змінної делегата
            DelAverage delAverage = AverageS;

            // вивід інформації
            Console.WriteLine("\n\tСереднє арифметичне значення цих чисел: " +
                $"{delAverage(abc[0], abc[1], abc[2]):N2}");
#endif
            #endregion

            #region 2. Спосіб. Через метод і делегат
#if false
            // створення змінної делегата
            DelAverage delAverage = new Program().Average;

            // вивід інформації
            Console.WriteLine("\n\tСереднє арифметичне значення цих чисел: " +
                $"{delAverage(abc[0], abc[1], abc[2]):N2}");
#endif
            #endregion

            #region 3. Спосіб. Через анонімний метод
#if false
            // створення змінної делегата
            DelAverage delAverage = delegate(int a, int b, int c)
            {
                // економія часу і місця
                return AverageS(a, b, c);
            };

            // вивід інформації
            Console.WriteLine("\n\tСереднє арифметичне значення цих чисел: " +
                $"{delAverage(abc[0], abc[1], abc[2]):N2}");
#endif
            #endregion

            #region 4. Спосіб. Через лямда-вираз
#if false
            // створення змінної делегата
            DelAverage delAverage = (a, b, c) => AverageS(a, b, c);

            // вивід інформації
            Console.WriteLine("\n\tСереднє арифметичне значення цих чисел: " +
                $"{delAverage(abc[0], abc[1], abc[2]):N2}");
#endif
            #endregion

            #region 5. Спосіб. Через лямда-вираз і без використання метода
#if true
            // створення змінної делегата
            DelAverage delAverage = (a, b, c) => (a + b + c) / 3.0;

            // вивід інформації
            Console.WriteLine("\n\tСереднє арифметичне значення цих чисел: " +
                $"{delAverage(abc[0], abc[1], abc[2]):N2}");
#endif
            #endregion

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Розрахунок середнього африметичного статичним методом
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static double AverageS(int a, int b, int c)
        {
            return (a + b + c) / 3.0;
        }

        /// <summary>
        /// Розрахунок середнього африметичного
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private double Average(int a, int b, int c)
        {
            return (a + b + c) / 3.0;
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
