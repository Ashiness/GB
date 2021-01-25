using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        class Fraction
        {
            private int a = 0;
            private int b = 0;

            public Fraction(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
             public override string ToString()
            {
                return a.ToString() + "/" + b.ToString();
            }
            public static Fraction operator +(Fraction a, Fraction b)
            {
                Fraction t = new Fraction(1, 1);
                t.a = (a.a * b.b + a.b * b.a);
                t.b = a.b * b.b;
                return t;
            }
            public static Fraction operator -(Fraction a, Fraction b)
            {
                Fraction t = new Fraction(1, 1);
                t.a = (a.a * b.b - a.b * b.a);
                t.b = a.b * b.b;
                return t;
            }
            public static Fraction operator *(Fraction a, Fraction b)
            {
                Fraction t = new Fraction(1, 1);
                t.a = (a.a * b.b * a.b * b.a);
                t.b = a.b * b.b;
                return t;
            }
            public static Fraction operator /(Fraction a, Fraction b)
            {
                Fraction t = new Fraction(1, 1);
                t.a = (a.a * b.b / a.b * b.a);
                t.b = a.b * b.b;
                return t;
            }
        }
        
        struct Complex
        {
            public double im;
            public double re;

            public Complex Plus(Complex x)
            {
                Complex y;
                y.im = im + x.im;
                y.re = re + x.re;
                return y;
            }

            public Complex Minus(Complex x)
            {
                Complex y;
                y.im = im - x.im;
                y.re = re - x.re;
                return y;
            }

            public Complex Mult(Complex x)
            {
                Complex y;
                y.im = im * x.im;
                y.re = re * x.re;
                return y;
            }

            public Complex Divide(Complex x)
            {
                Complex y;
                y.im = im / x.im;
                y.re = re / x.re;
                return y;
            }

            public override string ToString()
            {
                return $"{re} + {im}i";
            }



        }

        static void Main(string[] args)
        {
            Console.WriteLine("1 - арифметические операции над структурой Complex \n2 - Подсчёт суммы нечетных чисел \n3 - арифметические операции с дробями");
            Console.WriteLine("Выберите задание");
            string caseSwitch = Console.ReadLine();
            Console.ReadLine();

            switch (caseSwitch)
            {
                #region Task 1
                case "1":

                    Complex complex1;
                    Console.WriteLine("Введите первое действительное число: ");
                    complex1.re = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите первое мнимое число: ");
                    complex1.im = Convert.ToDouble(Console.ReadLine());


                    Complex complex2;
                    Console.WriteLine("Введите второе действительное число: ");
                    complex2.re = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите первое мнимое число: ");
                    complex2.im = Convert.ToDouble(Console.ReadLine());


                    Complex res = complex1.Plus(complex2);

                    Complex result = complex1.Minus(complex2);

                    Complex resultat = complex1.Mult(complex2);

                    Complex r = complex1.Divide(complex2);

                    Console.WriteLine($"{res}");
                    Console.WriteLine($"{result}");
                    Console.WriteLine($"{resultat}");
                    Console.WriteLine($"{r}");


                    Console.ReadKey();


                    break;
                #endregion
                #region Task 2
                case "2":

                    Console.WriteLine("Введите число: ");
                    string str = Console.ReadLine();
                    int Result = 0;
                    bool isNum = int.TryParse(str, out int typing);
                    if (isNum)
                    {
                        while (typing != 0)
                        {
                            if (typing >= 0)
                            {
                                if (typing % 2 != 0)
                                {
                                    Result = Result + typing;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели некоректное число");
                            }
                            int.TryParse(Console.ReadLine(), out typing);
                        }
                        Console.WriteLine(typing);
                        Console.WriteLine($"Сумма нечётных чисел {Result}");
                    }
                    else
                    {
                        Console.WriteLine("Это текст");
                    }
                    
                    

                    break;
                #endregion
                #region Task 3
                case "3":
                    Console.WriteLine("Введите числитель первого числа: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите знаменатель первого числа: ");
                    int y = int.Parse(Console.ReadLine());
                    Fraction a = new Fraction(x, y);
                    Console.WriteLine("Введите числитель второго числа: ");
                    int z = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите знаменатель второго числа: ");
                    int l = int.Parse(Console.ReadLine());
                    Fraction b = new Fraction(z, l);

                    Console.WriteLine(a.ToString() + "+" + b.ToString() + "=" + (a + b).ToString());
                    Console.WriteLine(a.ToString() + "-" + b.ToString() + "=" + (a - b).ToString());
                    Console.WriteLine(a.ToString() + "*" + b.ToString() + "=" + (a * b).ToString());
                    Console.WriteLine(a.ToString() + "/" + b.ToString() + "=" + (a / b).ToString());

                    break;
                #endregion


                default:
                    Console.WriteLine("Завершение программы");

                    break;
            }
        }
    }
}