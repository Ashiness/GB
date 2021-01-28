using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    
    public class NewArray
    {
        int[] a;
        private Stream fileName3;

        public NewArray(ref int n, ref int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }
        public NewArray(ref int n, ref int firstElement, ref int step)
        {
            a = new int[n];
            a[0] = firstElement;
            for (int i = 1; i < n; i++)
                a[i] = a[i - 1] + step;
        }
        public NewArray(ref string fileName3)
        {
            if (File.Exists(fileName3))
            {
                string[] ss = File.ReadAllLines(fileName3);
                a = new int[ss.Length];
                for (int i = 0; i < ss.Length; i++)
                    a[i] = int.Parse(ss[i]);
            }
            else Console.WriteLine("Ошибка загрузки файла");
        }
        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        public int Sum1
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                    sum += a[i];
                return sum;
            }
        }
        public int Inverse
        {
            set
            {
                for (int i = 0; i < a.Length; i++)
                    a[i] = a[i] * -1;
            }
        }
        public int Multiply
        {
            set
            {
                for (int i = 0; i < a.Length; i++)
                    a[i] = a[i] * value;
            }
        }
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 0; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }
        public int CountPisitive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }
        public int MaxCount
        {
            get
            {
                int max = Max;
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] == max) count++;
                return count;
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }
        public void SaveIntoFile(string fileName3)
        {
            StreamWriter sw = new StreamWriter(fileName3);
            for (int i = 0; i < a.Length; i++)
            {
                sw.WriteLine(a[i]);
            }
            sw.Close();
        }
        public void LoadFromFile(string fileName3)
        {
            StreamReader sr = new StreamReader(fileName3);
            int N = 0;
            while (sr.ReadLine() != null) { N++; }

            a = new int[N];
            sr.DiscardBufferedData();
            sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            for (int i = 0; i < N; i++)
            {
                a[i] = int.Parse(sr.ReadLine());
            }
            sr.Close();
        }
    }

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
        public void IndexOfMax(out string index)
        {
            index = "-1, -1";
            int max = Max;
            for(int i = 0; i < t.GetLength(0); i++)
                for( int j = 0; j < t.GetLength(1); j++)
                    if (t[i, j] == max)
                        index = i + ", " + j; 
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

                var Login = sr.ReadLine();

                var Password = sr.ReadLine();

                sr.Close();
            }
        }

            static bool AuthorizationCheck(Authorization toCheck)
            {
                if (toCheck.Login == "root" && toCheck.Password == "GeekBrains")
                    return true;
                else
                    return false;
            }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задание");
            Console.WriteLine("1 - массив из 20 элементов\n2 - дописанный класс\n3 - Авторизация\n4 - двумерный массив");
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

                    Console.WriteLine("Введите размер массива: ");
                    int size = GetInt();
                    Console.WriteLine("Введите первый элемент массива: ");
                    int firstElement = GetInt();
                    Console.WriteLine("Введите шаг добавления последующих элементов: ");
                    int step = GetInt();

                    NewArray b = new NewArray(ref size, ref firstElement, ref step);

                    Console.WriteLine($"Создан массив: [ {b.ToString()} ]");

                    Console.WriteLine($"Сумма элементов массива: {b.Sum1}");

                    b.Inverse = -1;

                    Console.WriteLine($"Массив с изменёнными знаками: [ {b.ToString()} ]");

                    Console.WriteLine("Введите множитель: ");

                    b.Multiply = GetInt();

                    Console.WriteLine($"Массив, умноженный на {b.ToString()}");

                    Console.WriteLine($"Максимальный элемент массива: {b.Max}");

                    Console.WriteLine($"Количество максимальных элементов массива: {b.MaxCount}");

                    Console.WriteLine("--------------------------------------------------------------------------");

                    string fileName3 = "..\\..\\array.txt";
                    NewArray newArray = new NewArray(ref fileName3);

                    newArray.SaveIntoFile(fileName3);

                    Console.WriteLine($"Создан следующий массив: [ {newArray.ToString()} ]");

                    string fileName4 = "..\\..\\anotherArray.txt";

                    newArray.SaveIntoFile(fileName3);

                    Console.WriteLine($"Загружен следующий массив: [ {newArray.ToString()} ]");

                    newArray.LoadFromFile(fileName4);

                    NewArray newArray1 = new NewArray(ref fileName3);

                    Console.WriteLine($"Проверка содрежимого файла: [ {newArray1.ToString()} ]");

                    Console.ReadKey();
                    
                    break;

                #endregion

                #region Task 3

                case "3":
                    
                    int count = 0;

                    Authorization authorization;
                    

                    string[] fileName = { "data.txt", "tryData.txt" };

                    int i = 1;

                    do
                    {
                        Console.WriteLine("Введите логин: ");
                        authorization.Login = Console.ReadLine();
                        Console.WriteLine("Введите пароль: ");
                        authorization.Password = Console.ReadLine();

                        authorization.LoadForFile(fileName[i]);

                        if (AuthorizationCheck(authorization))
                        {
                            Console.WriteLine("Успешный вход");

                            break;
                        }
                        else
                        {
                            Console.WriteLine("В доступе отказано");
                            Console.ReadLine();
                            ++count;
                        }
                        
                    }while (count < 3);

                    Console.WriteLine($"Попыток ввода: {count}");

                    Console.ReadKey();
                    
                    break;

                #endregion

                #region Task 4

                case "4":

                    Console.WriteLine("Введите количество строк массива: ");
                    int size1 = GetInt();
                    Console.WriteLine("Введите количество столбцов массива: ");
                    int size2 = GetInt();

                    TwoDimentionalArray a = new TwoDimentionalArray(size1, size2);

                    Console.WriteLine("Массив создан");

                    a.PrintDinArr(a.toString());

                    long sum = 0;
                    a.Sum(out sum);

                    Console.WriteLine($"Сумма элементов массива: {sum}");

                    a.SumMorThan(out sum, a.t[0, 0]);
                    Console.WriteLine($"Сумма элемeнтов массива, которые больше первого элемента: {sum}");

                    Console.WriteLine($"Максимальный элемента массива {a.Max}");
                    Console.WriteLine($"Минимальны элемента массива {a.Min}");

                    string numOfMax = "";
                    a.IndexOfMax(out numOfMax);
                    Console.WriteLine($"Индекс максимальногоэлемента: {numOfMax}");

                    Console.WriteLine("---------------------------------------------------------------------------");

                    TwoDimentionalArray myDimArr = new TwoDimentionalArray();

                    var fileName1 = "loadArray.txt";
                    var fileName2 = "saveArray.txt";

                    myDimArr.LoadFromFile(fileName1);

                    Console.WriteLine($"Загрузка массива из файла {fileName1}");
                    Console.WriteLine("Загрузка следующего массива");

                    myDimArr.PrintDinArr(myDimArr.toString());

                    Console.WriteLine($"Загрузка массива в файл {fileName2}");

                    myDimArr.SaveIntoFile(fileName2);

                    TwoDimentionalArray anotherDimArr = new TwoDimentionalArray(fileName2);

                    Console.WriteLine($"Проверка файла, загрузка нового массива: ");

                    anotherDimArr.PrintDinArr(anotherDimArr.toString());

                    Console.ReadKey();

                    break;

                #endregion
                    
                default:
                    Console.WriteLine("Завершение программы");
                    break;
            }

        }
    }
}
