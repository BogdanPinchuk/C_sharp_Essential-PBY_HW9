using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Примітка. для спрощення коду, не розділятимемо
// арифметичні операції на цілочисельний і дійсний вивід значень
// припустимо, що все виводитиметься в дійсних числах

namespace LesApp1
{
    /// <summary>
    /// Делегат калькулятора - арифметичних дій
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    delegate void DelCalc(double a, double b);
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // випадкові числа
            Random rnd = new Random();

            // випадкові цілі числа (великі числа погіршують читабельність)
            #region Створення цілих чисел
            double[] ab = new double[]
                {
                    rnd.Next(sbyte.MinValue, sbyte.MaxValue),
                    rnd.Next(sbyte.MinValue, sbyte.MaxValue)
                };

            // виведення на екран
            Console.WriteLine("\nЗгенеровані випадкові числа:\n");
            Console.WriteLine($"\tA = {ab[0]:N0}");
            Console.WriteLine($"\tB = {ab[1]:N0}\n");
            #endregion

            // створення змінної делегата
            // не бачу смисла виносити окремо виведення інформації
            // за межи лямда-виразу, вважаємо що резульатат -
            // це повернення виведення виразу в консоль
            DelCalc delCalc = (a, b) =>
            Console.WriteLine($"\t{a} + {b} = {a + b:N0}");

            delCalc += (a, b) =>
            Console.WriteLine($"\t{a} - {b} = {a - b:N0}");

            delCalc += (a, b) =>
            Console.WriteLine($"\t{a} * {b} = {a * b:N0}");

            delCalc += (a, b) =>
            {
                double temp = default;

                if (a == 0 && b == 0) { temp = double.NaN; }
                else if (a > 0 && b == 0) { temp = double.PositiveInfinity; }
                else if (a < 0 && b == 0) { temp = double.NegativeInfinity; }
                else { temp = a / b; }

                Console.WriteLine($"\t{a} / {b} = {temp:N2}");
            };

            // вивід результату
            delCalc(ab[0], ab[1]);

            // повторення
            DoExitOrRepeat();
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
