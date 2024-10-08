using System.ComponentModel.Design;

namespace Lab3
{
    internal class Lab3
    {
        private static void Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Вывести все предложения в порядке возрастания количества слов.");
            Console.WriteLine("2. Вывести все предложения в порядке возрастания длины предложения.");
            Console.WriteLine("3. Найти слова заданной длины в вопросительных предложениях.");
            Console.WriteLine("4. Удалить из текста все слова заданной длины, начинающиеся с согласной.");
            Console.WriteLine("5. Заменить слова заданной длины на указанную подстроку.");
            Console.WriteLine("6. Удалить стоп-слова из текста.");
            Console.WriteLine("7. Экспортировать текст в XML-документ.");
            Console.WriteLine("0. Выход.");
            Console.Write("Выберите действие: ");
        }

        public static void Main(string[] args)
        {
            ParseII parser = new ParseII("text.txt");
            parser.Run();

            Text tokenedText = parser.GetParsedText();
            parser.Print();

            bool isValidKey = false;  

            while (!isValidKey)
            {
                Menu();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);  

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Вы нажали 1");
                        tokenedText.SortSentencesByWordCount();

                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Вы нажали 2");
                        tokenedText.SortSentencesByLength();

                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Вы нажали 3");
                        tokenedText.SortSentencesByWordCount();

                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Вы нажали 4");

                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Вы нажали 5");

                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        Console.WriteLine("Вы нажали 6");

                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine("Вы нажали 7");

                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("Вы нажали Esc. Завершение программы.");

                        isValidKey = true;
                        break;
                    default:
                        Console.WriteLine("Неверная клавиша. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
