using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Homework5
{
    struct Believe
    {
        public string Question;
        public string Answer;

        public void LoadForFile(string fileName)
        {
            fileName = "..\\..\\" + fileName;
            StreamReader sr = new StreamReader(fileName);

            var Qestion = sr.ReadLine();

            var Answer = sr.ReadLine();

            sr.Close();
        }
        public static string RandomQuestions()
        {

        }
    }
    struct Elemnt
    {
        public string NL;
        public double AverageScore;
    }
    static class Message
    {
        public static string text;

        static Message()
        {
            text = "За дверью открывался пустой облицованный деревом коридор. \n" +
                "В подсвечниках, закрепленных вдоль противоположной от двери стены, стояли большие желтые свечи. \n" +
                "Мор выскользнул в коридор и бочком двинулся по стене, пока не достиг лестничного пролета. \n" +
                "Он успешно преодолел его, причем процесс преодоления не прерывался никакими явлениями призрачного характера. \n" +
                "В итоге он прибыл в помещение, напоминавшее прихожую с большим количеством дверей.";
        }
        static public void GetWordsByLength(int len)
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            Console.WriteLine($"Вывод слов, длинной не более {len} :");
            foreach (string word in words)
            {
                if (word == "")
                    continue;
                if (word.Length <= len)
                    Console.Write(word + " ");
            }
        }
        static public void DeleteWordsByLastChar(char ch)
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            Console.WriteLine($"Будут удалены слова включающие в себя {ch} :");
            foreach (string word in words)
            {
                if (word == "")
                    continue;
                if (word[word.Length - 1] == ch)
                {
                    Console.Write(word + " ");
                    text.Replace(word, "");
                }
            }
            Console.WriteLine($"Текст изменен на {text}");
        }
        static public string FindMaxWordLength()
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            string wordMax = words[0];
            int max = words[0].Length;

            foreach (string word in words)
            {
                if (word.Length > max)
                {
                    max = word.Length;
                    wordMax = word;
                }
            }
            Console.WriteLine($"Самое длинное слово: {wordMax}");
            return wordMax;
        }
        static public StringBuilder GetLongestString()
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t'});
            StringBuilder result = new StringBuilder();
            int max = Message.FindMaxWordLength().Length;
            foreach (string word in words)
            {
                if (word.Length == max)
                {
                    result.Append(word.ToLower() + " ");
                }
            }
            Console.WriteLine($"Самые длинные слова: {result}");
            return result;
        }
    }
    class Program
    {
        private static bool IsLatinLetter(char letter) //метод проверки символа латинская буква
        {
            int num = letter;
            if ((num >= 65 && num <= 90) || (num >= 97 && num <= 123))
                return true;
            else
                return false;
        }
        static bool CheckLogin(string login) //метод проверки правильности логина
        {
            int length = login.Length;
            if (length >= 2 && length <= 10)
            {
                bool check = true;
                char letter = login[0];
                if (Char.IsDigit(letter))
                    return false;
                for (int i = 1; i < length; i++)
                {
                    letter = login[i];
                    if (!(Char.IsDigit(letter) || IsLatinLetter(letter)))
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                    return true;
            }
            return false;
        }
        static bool LogRegular(string login) //метод для проверки регулярного числа
        {
            char letter = login[0];
            if (Char.IsDigit(letter)) 
               return false;
            if (Regex.IsMatch(login, @"^[A - Za - z0-9]{2,10}$"))
            {
                Console.WriteLine("OK");
                return true;
                
            }
            else
            {
                Console.WriteLine("ne ok");
                return false;
            }
        }
        static bool isThisPermutation(string s1, string s2)
        {
            return s1.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(s2.Select(Char.ToUpper).OrderBy(x => x));
        }
        static bool isThisAnotherPermutation(string s1, string s2)
        {
            s1 = s1.ToLower();
            s2 = s2.ToLower();

            string news1 = s1[0].ToString();
            string news2 = s2[0].ToString();

            for (int i = 1; i < s1.Length; i++)
                putCharIntoStr(ref news1, s1[1]);

            for (int i = 1; i < s2.Length; i++)
                putCharIntoStr(ref news2, s2[1]);

            if (news1.Equals(news2))
                return true;
            else
                return false;
        }
        static void putCharIntoStr (ref string s, char ch)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > ch)
                {
                    s = s.Insert(i, ch.ToString());
                    break;
                }
                else
                {
                    if (i == s.Length - 1)
                    {
                        s += ch.ToString();
                        break;
                    }
                }
            }
        }
        static void SortStud(ref Elemnt[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = 0; j < students.Length-i-1; j++)
                {
                    if (students[j].AverageScore > students[j + 1].AverageScore)
                    {
                        Elemnt tmp = students[j + 1];
                        students[j + 1] = students[j];
                        students[j] = tmp;
                    }
                }
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

                    int count = 0;

                    do
                    {
                        Console.Write("Введите логин: ");
                        string login = Console.ReadLine();

                        if (LogRegular(login))
                        {
                            Console.WriteLine("Логин подходит");
                            break;
                        }
                        else
                        {
                            count++;
                            Console.WriteLine("Логин не подходит\nЛогин должен быть от 2 до 10 символов, содержать только латинские символы, цифры не должны быть в начале логина");
                            Console.WriteLine(LogRegular(login));
                        }
                    } while (count < 3);

                    Console.WriteLine($"Было совершено попыток ввода: {count}");
                    Console.WriteLine("Завершение работы");

                    do
                    {
                        Console.Write("Введите логин: ");
                        string login = Console.ReadLine();

                        if (CheckLogin(login))
                        {
                            Console.WriteLine("Логин подходит");
                            break;
                        }
                        else
                        {
                            count++;
                            Console.WriteLine("Логин не подходит\nЛогин должен быть от 2 до 10 символов, содержать только латинские символы, цифры не должны быть в начале логина");
                        }
                    } while (count < 3);

                    Console.WriteLine($"Было совершено попыток ввода: {count}");
                    Console.WriteLine("Завершение работы");

                    break;

                #endregion

                #region Task 2

                case "2":

                    Console.WriteLine($"Дан текст: \n{Message.text}");

                    Console.WriteLine("Выберите размер слова: ");
                    int i = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Выведены слова по заданному размеру: {i}");
                    Message.GetWordsByLength(i);

                    Console.ReadLine();
                    Console.ReadKey();

                    Console.WriteLine("Выберите букву для удаления: ");
                    char l = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine($"Удаление слов из текста, заканчивающиеся на {l}");
                    Message.DeleteWordsByLastChar(l);

                    Console.ReadKey();

                    Console.WriteLine($"Самое длинное слово в тексте: {Message.FindMaxWordLength()}");

                    Console.WriteLine($"Сформированная строка  из самых длинных слов текста: {Message.GetLongestString()}");

                    Console.ReadKey();


                    break;

                #endregion

                #region Task 3

                case "3":

                    Console.WriteLine("Напишите первое слово");
                    string first = Console.ReadLine();
                    Console.WriteLine("Напишите второе слово");
                    string second = Console.ReadLine();

                    Console.WriteLine($"Сравнение строк {first} и {second}");

                    if (isThisPermutation(first, second) == true)
                        Console.WriteLine("Строки являются перестановками друг друга.");
                    else
                        Console.WriteLine("Строки состоят из уникальных символов.");

                    Console.ReadKey();

                    Console.WriteLine($"Сравнение строк {first} и {second}");

                    if (isThisAnotherPermutation(first, second) == true)
                        Console.WriteLine("Строки являются перестановками друг друга.");
                    else
                        Console.WriteLine("Строки состоят из уникальных символов.");

                    Console.ReadKey();

                    break;

                #endregion

                #region Task 4

                case "4":

                    int AOWS = 3;
                    StreamReader sr = new StreamReader("..\\..\\list.txt");
                    int N = int.Parse(sr.ReadLine());
                    Elemnt[] a = new Elemnt[N];
                    for (int p = 0; p < N; p++)
                    {
                        string[] s = sr.ReadLine().Split(' ');
                        a[p].NL = s[0] + " " + s[1];
                        a[p].AverageScore = (double.Parse(s[2]) + double.Parse(s[3]) + double.Parse(s[4])) / 3;
                    }
                    sr.Close();

                    SortStud(ref a);

                    String result = String.Format("{0, -20} {1, -10} \n\n", "Ученик", "Средний балл");

                    Elemnt prev = a[0];

                    for (int p = 0; p < AOWS; p++)
                    {
                        if (p > 0)
                        {
                            if (prev.AverageScore == a[p].AverageScore)
                                AOWS++;
                            prev = a[p];
                        }
                        result += String.Format("{0, -20} {1, -10:F2}\n", a[p].NL, a[p].AverageScore);
                    }
                    Console.WriteLine("Три самых худших ученика по среднему баллу");

                    Console.WriteLine($"{result}");

                    Console.ReadKey();

                    break;

                #endregion

                #region Task 5

                case "5":

                    int score = 0;

                    Believe believe;

                    string[] fileName = { "BelieveOrNot.txt "};

                    int questions = 0;

                    do
                    {

                    } while (questions < 5);

                    break;

                #endregion

                default:
                    Console.WriteLine("Завершение программы");
                    break;
            }
        }
    }
}
