using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Примітка. Делегати не дружать із масивами і циклами наприклад for
// так як відбувається замикання змінних, і вона живе до тих пір доки
// не живий делегат, а при повторному поверненню до делегата,
// лічильник виставлено на +1 і звернення до масиву відбувається 
// за його межі, що викликає "виключення" - помилку
// єдиним дружелюбними масивами з делегатами є колекції

namespace LesApp2
{
    class Program
    {
        delegate double DelAvarage(List<DelRandom> delegates);
        delegate int DelRandom();

        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // випадкові числа
            Random rnd = new Random();

            // анонімний метод, який приймає масив делегатів
            // і розраховує їх середнє арифметичне
            DelAvarage delAvarage = delegate (List<DelRandom> delegates)
            {
                int sum = 0;
                foreach (var i in delegates)
                {
                    sum += i();
                }

                return (double)sum / delegates.Count;
            };

            // внутрішній делегат, який повертає випадкове значення int
            // такий варіант не підходить, томущо скільки раз визивається,
            // стільки раз і будуть перегенеровуватись значення
            //DelRandom delRandom = () => rnd.Next(sbyte.MinValue, sbyte.MaxValue);

            // задаємо певну кількість делегатів
            int countDel = rnd.Next(1, 10);

            // створюємо для стабільності масив значень
            List<int> array = new List<int>();

            // заповнюємо масив
            for (int i = 0; i < countDel; i++)
            {
                array.Add(rnd.Next(sbyte.MinValue, sbyte.MaxValue));
            }

            // створюєм масив внутрішніх делегатів
            List<DelRandom> delRandoms = new List<DelRandom>();

            // заповнення масиву делегатів
            foreach (var i in array)
            {
                delRandoms.Add(() => i);
            }

            // передача масиву делегатів, для розрахунку середнього арифметичного
            double res = delAvarage(delRandoms);

            // виведення результату
            Console.WriteLine("\nЗгенеровані значення:\n");
            foreach (var i in array)
            {
                Console.WriteLine($"\t{i:N0}");
            }

            Console.WriteLine("\nСереднє арифметичне:");
            Console.Write($"\n\t{res:N2}");

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
