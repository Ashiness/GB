using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{

    public class MyArray
    {
        private int[] am;
        public MyArray(int n, int min, int max)
        {
            am = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
                am[i] = random.Next(min, max);
        }
        public int DividedOn3()
        {
            int count = 0;
            for (int i = 0; i < am.Length - 1; i++)
            {
                if (am[i] % 3 == 0 || am[i + 1] % 3 == 0)
                    count++;
                Console.WriteLine("Пара чисел: {0} и {1}", am[i], am[i + 1]);
            }
            Console.WriteLine("Количество пар: " + count);
            return count;
        }
        public override string ToString()
        {
            string stringArray = "";
            foreach (int x in am)
                stringArray = stringArray + x + " ";
            return stringArray;
        }
    }
    
    class TwoDimentionalArray
    {
        public int[,] t;

        public TwoDimentionalArray() { }

        public TwoDimentionalArray(int n, int m)
        {
            t = new int[n, m];
            Random rng = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    t[i, j] = rng.Next();
        }
        public TwoDimentionalArray(string fileName)
        {
            fileName = "..\\..\\" + fileName;
            string[] ss = new string[0];
            try
            {
                ss = File.ReadAllLines(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл не существует в: {fileName}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Обнаружено исключение: {ex.Message}");
            }

            t = new int[ss.Length, ss.Length];

            for(int i = 0; i < ss.Length; i++)
            {
                string[] tempArray = ss[i].Split(' ');
                for (int j = 0; j < ss.Length; j++)
                {
                    t[i, j] = int.Parse(tempArray[j]);
                }
            }
        }
        public int Max
        {
            get
            {
                int max = t[0, 0];
                for (int i = 0; i < t.GetLength(0); i++)
                    for (int j = 0; j < t.GetLength(1); j++)
                        if (t[i, j] > max) max = t[i, j];

                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = t[0, 0];
                for (int i = 0; i < t.GetLength(0); i++)
                    for (int j = 0; j < t.GetLength(1); j++)
                        if (t[i, j] < min) min = t[i, j];
                return min;
            }
        }
        public void Sum(out long sum)
        {
            sum = 0;
            for (int i = 0; i < t.GetLength(0); i++)
                for (int j = 0; j < t.GetLength(1); j++)
                    sum += t[i, j];
        }
        public void SumMorThan(out long sum, int min)
        {
            sum = 0;
            for (int i = 0; i < t.GetLength(0); i++)
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    if (t[i, j] > min)
                        sum += t[i, j];
                }
        }
        
        public string[] toString()
        {
            string[] s = new string[t.GetLength(0)];

            for (int i = 0; i < t.GetLength(0); i++)
            {
                s[i] += "[ ";
                for (int j = 0; j < t.GetLength(1); j++)
                    s[i] += String.Format($"{t[i, j]:D100} ");
                s[i] += " ]";
            }
            return s;
        }
        public void PrintDinArr(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        public void SaveIntoFile(string fileName)
        {
            fileName = "..\\..\\" + fileName;

            try
            {
                StreamWriter wr = new StreamWriter(fileName);
                for (int i = 0; i < t.GetLength(0); i++)
                {
                    for (int j = 0; j < t.GetLength(1); j++)
                        wr.Write(t[i, j] + " ");
                    wr.Write(Environment.NewLine);
                }
                wr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл не существует в: {fileName}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Обнаружено исключение: {ex.Message}");
            }
        }
        public void LoadFromFile(string fileName)
        {
            fileName = "..\\..\\" + fileName;

            try
            {
                StreamReader sr = new StreamReader(fileName);
                int N = 0;
                while (sr.ReadLine() != null) { N++; }

                t = new int[N, N];
                sr.DiscardBufferedData();
                sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                for (int i = 0; i < N; i++)
                {
                    string[] tempArray = sr.ReadLine().Split(' ');
                    for (int j = 0; j < tempArray.Length; j++)
                        t[i, j] = int.Parse(tempArray[j]);
                }
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл не существует в: {fileName}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Обнаружено исключение: {ex.Message}");
            }
        }
    }

    class Program
    {
        static int GetInt()
        {
            while (true)
                if (!int.TryParse(Console.ReadLine(), out int x))
                    Console.WriteLine("Неверный ввод, тебуется число: ");
                else return x;
        }
        struct Authorization
        {
            public string Login;
            public string Password;

            public void LoadForFile(string fileName)
            {
                fileName = "..\\..\\" + fileName;
                StreamReader sr = new StreamReader(fileName);

                Login = sr.ReadLine();

                Password = sr.ReadLine();

                sr.Close();
            }

            static bool AuthorizationCheck(Authorization toCheck)
            {
                if (toCheck.Login == "root" && toCheck.Password == "GeekBrains")
                    return true;
                else
                    return false;
            }
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

                    MyArray myArray = new MyArray(20, -10000, 10000);
                    Console.WriteLine(myArray.ToString());
                    myArray.DividedOn3();
                    Console.ReadLine();

                    break;

                #endregion

                #region Task 2

                case "2":


                    
                    break;

                #endregion

                #region Task 3

                case "3":
                    /*
                    Console.WriteLine("Проверка логина и пароля из файла ");
                    int amountOfTries = 3;

                    string[] fileName = { "data.txt", "tryData.txt", "reallyTryData.txt" };

                    Authorization authorization;
                    authorization.Login = "";
                    authorization.Password = "";

                    int i = 0;

                    do
                    {
                        Console.WriteLine(fileName[i]);
                        authorization.LoadForFile(fileName[i]);

                        if (AuthorizationCheck(authorization))
                        {

                            break;
                        }
                        else
                        {
                            amountOfTries--;
                            Console.WriteLine($"Неверный ввод логина и пароля? попыток осталось: {amountOfTries}");
                        }
                        i++;
                    }while (amountOfTries > 0);
                    Console.WriteLine("Успешный вход");

                    Console.ReadKey();
                    */
                    break;

                #endregion

                #region Task 4

                case "4":



                    break;

                #endregion

                default:
                    Console.WriteLine("Завершение программы");
                    break;
            }

        }
    }
}
