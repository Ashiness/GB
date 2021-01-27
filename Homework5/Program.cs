using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework5
{
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
            if (!Regex.IsMatch(login, @"^[A - Za - z0-9]{2,10}$"))
                return false;
            return true;
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

                default:
                    Console.WriteLine("Завершение программы");
                    break;
            }
        }
    }
}
