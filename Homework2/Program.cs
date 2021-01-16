using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static bool Odd(int n)
        {
            return n % 2 ==  0;
        }
        static int Check(int a, int b, int c)
        {
            int min;

            if (a < b && a < c)
            {
                min = a;
            }
            else if (b < c && b < a)
            {
                min = b;
            }
            else
            {
                min = c;
            }
            return min;
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

                    Console.WriteLine("Введите a: ");
                    string a = Console.ReadLine();

                    Console.WriteLine("Введите b: ");
                    string b = Console.ReadLine();

                    Console.WriteLine("Введите c: ");
                    string c = Console.ReadLine();

                    Console.Write("Наименьшее число: ");

                    Console.WriteLine(Check(Convert.ToInt32(a), Convert.ToInt32(b), Convert.ToInt32(c)));

            break;
                #endregion
                #region Task 2
                case "2":

                    
            break;
                #endregion
                #region Task 3
                case "3":
                    Console.WriteLine("Введите число: ");
                    string typing = Console.ReadLine();
                    int Result = 0;
                    while (Convert.ToInt32(typing) > 0)
                    {
                        Console.WriteLine($"Вы ввели {typing}");
                        if(Convert.ToInt32(typing) % 2 != 0)
                        {
                            Result = Result + Convert.ToInt32(typing);
                        }
                        typing = Console.ReadLine();
                    }
                    Console.WriteLine($"Сумма нечётных чисел {Result}");
            break;
                #endregion
                #region Task 4
                case "4":

            break;
                #endregion
                #region Task 5
                case "5":

            break;
                #endregion
                #region Task 6
                case "6":

            break;
                #endregion
                #region Task 7
                case "7":
            
            break;
                #endregion

                default:
                    Console.WriteLine("Завершение программы");
                    
            break;
            }
        }
    }
}
