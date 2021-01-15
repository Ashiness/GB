using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB
{


    class Program
    {

        class MyClass
        {

            public static void Pause()
            {
            Console.ReadLine();
            }
            
            
           


            /// <summary>
            /// Расчет по формуле
            /// </summary>
            /// <param name="x1"> число A </param>
            /// <param name="x2"> число B </param>
            /// <param name="y1"> число C </param>
            /// <param name="y2"> число D </param>
            /// <returns> результат расчета </returns>
            static double CoordinatesFormula(double x1, double x2, double y1, double y2)//методя с формулой для расчёта
            {
                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }




            static void Main(string[] args)

            {
                #region Tests






                #endregion


                #region Task 1


                Console.Write("Ваше имя: "); //Ввод имени
                string name = Console.ReadLine(); //присванивание значения
                Console.Write("Ваша фамилия: ");
                string lastName = Console.ReadLine();
                Console.Write("Ваш возраст: ");
                string age = Console.ReadLine();
                Console.Write("Ваш рост: ");
                string height = Console.ReadLine();
                Console.Write("Ваш вес: ");
                string weight = Console.ReadLine();

                Console.WriteLine("Имя: " + name + "; Фамилия: " + lastName + "; Возраст: " + age + "; Рост: " + height + "; Вес: " + weight + "."); //вывод данных со склеиванием
                Console.WriteLine("Имя: {0}; Фамилия: {1}; Возраст: {2}; Рост: {3}; Вес: {4}.", name, lastName, age, height, weight); //вывод данных с форматированием
                Console.WriteLine($"Имя: {name}; Фамилия: {lastName}; Возраст: {age}; Рост: {height}; Вес: {weight}."); //вывод данных с интерполяцией
                Pause();
                Console.Clear();

                #endregion

                #region Task 2

                //формула подсчета индекса массы тела i=m/(h*h) m - масса тела h - рост

                Console.WriteLine("Расчёт индекса массы тела");
                double m = Convert.ToDouble(weight);
                double h = Convert.ToDouble(height);
                string i = Convert.ToString(m / (h * h) * 10000);
                Console.WriteLine("Индекс массы тела равен:" + i);
                Pause();
                Console.Clear();

                #endregion

                #region Task 3

                Console.Write(" Введите координату X первой точки  A: ");
                double A = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.Write(" Введите координату Y первой точки B: ");
                double B = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.Write(" Введите координату X второй точки C: ");
                double C = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.Write(" Введите координату Y второй точки D: ");
                double D = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                double result = 0;


                result = Math.Sqrt(Math.Pow((C - A), 2) + Math.Pow((D - B), 2)); //Формула расчёта

                Console.Write($" Расстояние между точками с координатами A = {A}, B = {B}, C = {C}, D = {D} равно: ");
                Console.Write("{0:0.00}", result); //Вывод 2 знаков после запятой
                Console.WriteLine();

                //Использование формулы через метод

                Console.Write(" Введите координату X первой точки  A: ");
                double x1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.Write(" Введите координату Y первой точки B: ");
                double x2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.Write(" Введите координату X второй точки C: ");
                double y1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                Console.Write(" Введите координату Y второй точки D: ");
                double y2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();


                CoordinatesFormula(x1, x2, y1, y2);//использование метода


                Console.Write($" Расстояние между точками с координатами A = {x1}, B = {x2}, C = {y1}, D = {y2} равно: ");
                Console.Write("{0:0.00}", result);
                Console.WriteLine();



                #endregion

                #region Task 4

                //поменять значения переменных
                Console.Write("первое число: ");
                string first = Console.ReadLine();
                Console.Write("Второе число: ");
                string second = Console.ReadLine();
                int a = Convert.ToInt32(first);
                int b = Convert.ToInt32(second);

                int tmp; //третья временная переменная

                tmp = a;
                a = b;
                b = tmp;
                Console.WriteLine($"первая переменная: {a}; вторая переменная: {b}");
                Pause();
                Console.Clear();

                //поменять значения переменной без 3 переменной
                Console.Write("первое число: ");
                string third = Console.ReadLine();
                Console.Write("Второе число: ");
                string fourth = Console.ReadLine();
                int c = Convert.ToInt32(third);
                int d = Convert.ToInt32(fourth);

                c = c + d;
                d = d - c;
                d = -d;
                c = c - d;

                Console.WriteLine($"первая переменная: {c}; вторая переменная: {d}");
                Pause();
                Console.Clear();



                #endregion

                #region Task 5


                Console.Write("Ваш город: ");
                string city = Console.ReadLine();
                Console.Clear();
                string centerText = ($"{name} {lastName} {city}");

                //калибровочные переменные для определения границ окна
                string topLeftText = " ";
                string topRightText = " ";
                string bottomLeftText = " ";
                string bottomRightText = " ";

                Console.Clear();

                //По умолчанию курсор находится в левом верхнем углу [0, 0]
                Console.Write(topLeftText);

                //Рассчет положение для строки в верхнем левом углу
                int topRightX = Console.WindowWidth - topRightText.Length;
                //Новые координаты курсора
                Console.SetCursorPosition(topRightX, 0);
                //Вывод текста
                Console.Write(topRightText);

                //Повтор действия для левого нижнего угла
                int bottomY = Console.WindowHeight - 1;
                Console.SetCursorPosition(0, bottomY);
                Console.Write(bottomLeftText);

                //Для правого нижнего угла
                int bottomRightX = Console.WindowWidth - bottomRightText.Length;
                Console.SetCursorPosition(bottomRightX, bottomY);
                Console.Write(bottomRightText);


                // Вывод строки в центр экрана
                int centerX = (Console.WindowWidth / 2) - (centerText.Length / 2);
                int centerY = (Console.WindowHeight / 2) - 1;
                Console.SetCursorPosition(centerX, centerY);
                Console.Write(centerText);

                //Ожидание нажатия клавиши перед выходом
                Console.ReadKey();

                #endregion

                #region Lesson 2

                #region Test

                #endregion


                #endregion

                #region E
                #region a
                #region s
                #region t
                #region e
                #region r
                #region E
                #region g
                #region g

                //Console.Write("Здесь могла быть ваша реклама "); //¯\_(ツ)_/¯
                //Console.ReadLine();
                #endregion
                #endregion
                #endregion
                #endregion
                #endregion
                #endregion
                #endregion
                #endregion
                #endregion

            }
        }
    }
}