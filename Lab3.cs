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
            Console.WriteLine("[ESC] -> Выход.\n");
            Console.Write("Выберите действие:\n");
        }

        public static void Main(string[] args)
        {
            ParseII parser = new ParseII("text.txt");
            parser.Run();
            Text tokenedText = parser.GetParsedText();
          
            bool isValidKey = false;  

            while (!isValidKey)
            {
                Console.Clear();
                Menu();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);  

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:

                        Console.WriteLine("\nВы нажали 1\n");
                        tokenedText.SortSentencesByWordCount();

                        break;
                    case ConsoleKey.D2:

                        Console.WriteLine("\nВы нажали 2\n");
                        tokenedText.SortSentencesByLength();

                        break;
                    case ConsoleKey.D3:

                        Console.WriteLine("Вы нажали 3");
                        tokenedText.SortSentencesByWordCount();

                        break;
                    case ConsoleKey.D4:

                        Console.WriteLine("Вы нажали 4");

                        break;
                    case ConsoleKey.D5:

                        Console.WriteLine("Вы нажали 5");

                        break;
                    case ConsoleKey.D6:

                        Console.WriteLine("Вы нажали 6");

                        break;
                    case ConsoleKey.D7:

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
