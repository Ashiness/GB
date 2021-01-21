using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        #region Метод Sum
        static int Sum()  //Метод посчета для задания 2
        {
            Console.Write("Введите число : ");
            int num = int.Parse(Console.ReadLine());
            int i = 0;
            while (num > 0)
            {
                i++;
                num /= 10;
            }
            Console.WriteLine("Количество цифр введенного числа : {0}", i);
            Console.ReadKey();
            return 0;
        }
        #endregion

        #region Метод Check
        static int Check(int a, int b, int c) //метод расчёта для задания 1
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
        #endregion

        #region Методы для ИМТ
        static string CheckBMI(double bmi, double height) //метод для впроверки Индекса массы тела и вывод результата
        {
            string result = "";
            if (bmi >= 18.5 && bmi <= 24.99)
            {
                result = "Всё в норме";
            }
            else if (bmi < 18.5)
            {
                result = String.Format("Обнаружен недостаток нормы веса!");
            }
            else if (bmi > 24.99)
            {
                result = String.Format("Обнаружено превышение нормы веса!");
            }


            return result;
        }
        static string CheckBodyMassIndex(double bmi, double height) //метод для проверки ИМТ и вывод результата с рекомендациями
        {
            string result = "";
            if (bmi >= 18.5 && bmi <= 24.99)
            {
                result = "Всё в норме";
            }
            else if (bmi < 18.5)
            {
                double recommendadtion = (18.5 - bmi) * height * height;
                result = String.Format("Необходимо набрать {0:0.00} кг для нормаизации веса!", recommendadtion);
            }
            else if (bmi > 24.99)
            {
                double recommendation = (bmi - 24.99) * height * height;
                result = String.Format("Необходимо сбросить {0:0.00} кг для нормализации веса!", recommendation);
            }


            return result;
        }
        #endregion
       
        #region Метод для чисел от a до b 
            static int AmountInNumber(string number) //Метод для Задания 7
        {
            return number.Length;
        }

        static string EnterCheck()
        {
            string number = "";
            bool checkNotANumber;
            do
            {
                checkNotANumber = false;
                number = Console.ReadLine();
                for (int i = 0; i < number.Length; i++)
                {
                    if (!Char.IsNumber(number, i))
                    {
                        checkNotANumber = true;
                        Console.WriteLine("Неверный ввод (нужно число).\nПожалуйста повторите ввод: ");
                        break;
                    }
                }
            } while (checkNotANumber);
            return number;
        }
        #endregion
        static void PrintNumber(int a, int b)
        {
            if (a <= b)
            {
                Console.WriteLine(a);
                a++;
                PrintNumber(a, b);
            }
        }

        static int SumNumber(int a, int b)
        {
            if (a <= b)
            {
                var sum = SumNumber(a + 1, b);
                return a + sum;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            //Меню для выбора задания
            Console.WriteLine(" 1 - Минимальное из 3 чисел \n 2 - Подсчет количества цифр \n 3 - Подсчет суммы чисел \n 4 - Проверка логина и пароля \n 5 - ИМТ \n 6 - Подсчёт <<Хороших>> чисел \n 7 - Вывод чисел в диапазоне");
            Console.WriteLine("Выберите задание");
            string caseSwitch = Console.ReadLine();
            Console.ReadLine();
            

            switch (caseSwitch) 
            {
                #region Task 1
                case "1": //Минимальное из 3 чисел

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

                    Sum();


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

                    string login = "root";
                    string password = "GeekBrains";

                    int count = 0;
                    do
                    {
                        Console.WriteLine("\nВведите Логин:");
                        string checkLogin = Console.ReadLine();

                        Console.WriteLine("\nВведите Пароль:");
                        string checkPassword = Console.ReadLine();

                        if (login == checkLogin && password == checkPassword)
                        {
                            Console.WriteLine("Добро пожаловать в систему");
                            Console.ReadLine();
                            break;
                        }
                            Console.WriteLine("В доступе отказано");
                            Console.ReadLine();
                            ++count;
                    }
                    while (count < 3 );
                    Console.WriteLine($"Вы сделали {count} попыток ввода");

                    break;
                #endregion
                #region Task 5
                case "5":

                    Console.WriteLine("Введите массу: ");
                    double mass = double.Parse(Console.ReadLine());

                    Console.WriteLine("Введите рост в см: ");
                    double height = double.Parse(Console.ReadLine());

                    height /= 100;

                    double BMI = mass / (height * height);

                    Console.WriteLine("Индекс массы тела: {0:0.##}", BMI );
                    Console.WriteLine(CheckBMI(BMI, height));

                    Console.WriteLine("Индекс массы тела: {0:0.##}", BMI);
                    Console.WriteLine(CheckBodyMassIndex(BMI, height));
                    Console.ReadLine();

                    break;
                #endregion
                #region Task 6
                case "6":

                    int goodnumcount = 0;
                    DateTime start = DateTime.Now;
                    int minNum = 1;
                    int maxNum = 1000000000;
                    int temp;
                    int testnum;

                    for (int num = minNum; num <= maxNum; num++)
                    {
                        temp = 0;
                        testnum = num;
                        while (testnum != 0)
                        {
                            temp += testnum % 10;
                            testnum /= 10;
                        }
                        if (num % temp == 0) goodnumcount++;
                    }
                    Console.WriteLine($"Количество хороших чисел {goodnumcount}");
                    Console.WriteLine(DateTime.Now - start);

                    break;
                #endregion
                #region Task 7
                case "7":
                    Console.WriteLine("Введите число: ");

                    string number = EnterCheck();

                    Console.WriteLine("Количество цифр: " + AmountInNumber(number));

                    Console.ReadKey();
            break;
                #endregion
                case "8":
                    Console.Write("Введите число a: ");

                    var aInput = Console.ReadLine();
                    var d = Convert.ToInt32(aInput);
                    Console.Write("Введите число b: ");
                    var bInput = Console.ReadLine();
                    var e = Convert.ToInt32(bInput);

                    PrintNumber(d, e);
                    Console.Write($"\nСумма всех чисел равна: { SumNumber(d, e)}");

                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Завершение программы");
                    
            break;
            }



            
        }
    }
}
