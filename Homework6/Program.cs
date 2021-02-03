using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public delegate double Func(double a, double x);
    public delegate double Func1(double x);
    class User
    {
        public string Course { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
    class Program
    {
        public static void TableFunc(Func F, double a, double x, double b)
        {
            Console.WriteLine("----- A ------- X -------- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.00} |", a, x, F(a,x));
                x += 1;
            }
            Console.WriteLine("----------------------------------");
        }
        public static double MyFunc(double a, double x)
        {
            return a * x * x;
        }
        public static double Sin(double a, double x)
        {
            return a * Math.Sin(x);
        }
        public static void SaveFunc(string fileName, double start, double end, double step, Func1 F)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            while (start <= end)
            {
                bw.Write(F(start));
                start += step;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double[] array = new double[fs.Length / sizeof(double)];
            min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                array[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return array;
        }
        static double secondDeree(double x)
        {
            return Math.Sqrt(x);
        }
        static double thirdDegree(double x)
        {
            return x * x * x;
        }
        static double MySqrt(double x)
        {
            return Math.Sqrt(x);
        }
        static double Sin1(double x)
        {
            return Math.Sin(x);
        }
        static int GetInt(int max)
        {
            while (true)
                if (!int.TryParse(Console.ReadLine(), out int x) || x > max)
                    Console.WriteLine("Неверный ввод, требуется число от 0 до {0}. \nПожалуйста, повторите ввод: ", max);
                else return x;
        }
        static void GetInterval(out double start, out double end)
        {
            string[] interval = Console.ReadLine().Split(' ');
            start = double.Parse(interval[0], CultureInfo.InvariantCulture);
            end = double.Parse(interval[1], CultureInfo.InvariantCulture);
        }
        static void PrintResult(double start, double end, double step, double[] values)
        {
            Console.WriteLine("------- X ------- Y -----");
            int index = 0;
            while (start <= end)
            {
                Console.WriteLine("| {0,8.0:000} | {1,8.0:000} |", start, values[index]);
                start += step;
                index++;
            }
            Console.WriteLine("--------------------------");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задание");
            string caseSwitch = Console.ReadLine();
            Console.ReadLine();

            switch (caseSwitch)
            {
                #region Task 1
                case "1":

                    Console.WriteLine("Функция a*x^2");
                    TableFunc(new Func(MyFunc), -1.5, -2, 2);

                    Console.WriteLine("Функция a*sin(x)");
                    TableFunc(new Func(MyFunc), 3, -2, 2);

                    Console.ReadKey();

                    break;
                #endregion

                #region Task 2
                case "2":

                    Console.WriteLine("Нахождение минимума функции");
                    List<Func1> functions = new List<Func1> { new Func1(secondDeree), new Func1(thirdDegree), new Func1(MySqrt), new Func1(Sin1) };
                    Console.WriteLine("Выберите функцию для дальнейшей работы");
                    Console.WriteLine("1) f(x)=y^2");
                    Console.WriteLine("2) f(x)=y^3");
                    Console.WriteLine("3) f(x)=y^1/2");
                    Console.WriteLine("4) f(x)=Sin(y)");
                    int userChoose = GetInt(functions.Count);

                    Console.WriteLine("Задайте отрезок нахождения минимума в формате 'x1 x2': ");

                    double start = 0;
                    double end = 0;
                    GetInterval(out start, out end);

                    Console.WriteLine("Задайте величину шага дискредетирования");
                    double step = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    SaveFunc("data.bin", start, end, step, functions[userChoose - 1]);
                    double min = double.MaxValue;
                    Console.WriteLine("Получены следующие значения функции: ");
                    PrintResult(start, end, step, Load("data.bin", out min));
                    Console.WriteLine("Минимальное значение функции равняется: {0:0.00}", min);
                    Console.ReadKey();

                    break;
                #endregion

                #region Task 3
                case "3":


                #endregion

                default:
                    Console.WriteLine("Завершение программы");
                    break;
            }

        }
    }
}
