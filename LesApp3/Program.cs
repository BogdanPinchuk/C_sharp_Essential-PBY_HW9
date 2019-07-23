using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        delegate double DelAvarage(params DelRandom[] delegates);
        delegate int DelRandom();

        // випадкові числа
        private static Random rnd = new Random();

        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            //// випадкові числа
            //Random rnd = new Random();

            // задаємо певну кількість делегатів
            int countDel = rnd.Next(1, 10);

            // створюємо масив делегатів
            DelRandom[] delRandoms = new DelRandom[countDel];

            // заповнення масива делегатами із зв'язуванням 
            // з певним методом який видає випадкове число
            for (int i = 0; i < delRandoms.Length; i++)
            {
                delRandoms[i] = Method;
            }

            // анонімний метод, який приймає масив делегатів
            // і розраховує їх середнє арифметичне
            DelAvarage delAvarage = delegate (DelRandom[] delegates)
            {
                Console.WriteLine("\nЗгенеровані значення:\n");
                int sum = 0;
                for (int i = 0; i < delegates.Length; i++)
                {
                    int temp = delegates[i]();
                    sum += temp;
                    Console.WriteLine($"\t{temp:N0}");
                }

                return (double)sum / delegates.Length;
            };

            // передача масиву делегатів, для розрахунку середнього арифметичного
            double res = delAvarage(delRandoms);

            Console.WriteLine("\nСереднє арифметичне:");
            Console.Write($"\n\t{res:N2}");

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод який повертає випадкове ціле число
        /// </summary>
        /// <returns></returns>
        private static int Method()
        {
            return rnd.Next(sbyte.MinValue, sbyte.MaxValue);
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
