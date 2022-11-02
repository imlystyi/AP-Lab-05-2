// Lab_05_2.cs
// Якубовський Владислав
// Лабораторна робота № 5.2
// Обчислення суми ряду Тейлора за допомогою функцій.
// Варіант 24
using System;
using static System.Math;

namespace AP_Lab_05_2
{
    public class Lab_05_2
    {
        public static double Summarize(double x, double eps, ref int n)
        {
            double a = x, sum = a;

            do
            {
                a = Reccurent(x, a, n);
                sum += a;

                n++;

            }
            while (Abs(a) >= eps);

            return sum;
        }

        static double Reccurent(double x, double a, int n)
        {
            double R = -(x * n / (n + 1));

            return a *= R;
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            int n;

            double xInital, xFinal, dx, eps, sum;

            string[] varArray;

            Console.Write("Введіть змінні \"x початкове\", \"x кінцеве\", \"dx\" та \"eps\" по черзі через крапку з комою: ");

            varArray = Console.ReadLine().Split(';');

            xInital = Double.Parse(varArray[0].Replace('.', ','));
            xFinal = Double.Parse(varArray[1].Replace('.', ','));
            dx = Double.Parse(varArray[2].Replace('.', ','));
            eps = Double.Parse(varArray[3].Replace('.', ','));

            /* Fool-checker, який запускається у тому випадку, якщо введені змінні не відповідають умові: -1 < {"х початкове", "х кінцеве"} < 1
             * та/або "x початкове" більше ніж "x кінцеве".  */
            while (!(xInital > -1) || !(xFinal <= 1) || xInital > xFinal)
            {
                Console.Write("Помилка! \"x початкове\" повинно бути більшим за -1, а \"x кінцеве\" - меншим або дорівнювати 1.\n" +
                    "Введіть нові значення дли цих змінних по черзі через крапку з комою: ");

                varArray = Console.ReadLine().Split(';');

                xInital = Double.Parse(varArray[0].Replace('.', ','));
                xFinal = Double.Parse(varArray[1].Replace('.', ','));
            }

            // Виведення "шапки таблиці"
            Console.WriteLine("+---------------+-----------------------+---------------+---------------+\n" +
                "|\tx\t|\tln(x + 1)\t|\tsum\t|\tn\t|\n" +
                "+---------------+-----------------------+---------------+---------------+");

            // Розрахунок значень та виведення основної частини таблиці
            for (double x = xInital; x <= xFinal; x += dx)
            {
                n = 1;
                sum = Summarize(x, eps, ref n);
                Console.WriteLine($"|\t{x:0.####}\t|\t{Log(x + 1):0.0000}\t\t|\t{sum:0.0000}\t|\t{n}\t|\n" +
                    $"+---------------+-----------------------+---------------+---------------+");
            }

            Console.ReadLine();
        }
    }
}