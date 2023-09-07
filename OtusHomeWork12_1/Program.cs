using System.Collections.Concurrent;
using OtusHomeWork12_1;

internal class Program
{
    static ConcurrentDictionary<string, int> _bookDictionary = new ConcurrentDictionary<string, int>();
    private static void Main(string[] args)
    {
        ReadFromConsole readParametr = new ReadFromConsole();
         
        while (true)
        {
            Console.WriteLine("Вас привествует Библиотека. Введите 1 - добавить книгу, 2 - вывести список непрочитанного, 3 - выйти.");
            var itemNumber = readParametr.ReadNumbersFromConsole();
            if (itemNumber == 1)
            {
                Console.WriteLine("Введите название книги:");
                var bookName = readParametr.ReadTextFromConsole();
                _bookDictionary.TryAdd(bookName, 0);
                Reading(bookName);
            }
            else if (itemNumber == 2)
            {
                var option = new ParallelOptions { MaxDegreeOfParallelism = 2 };
                Parallel.ForEach(_bookDictionary, option,  percentRead =>
                {
                    _bookDictionary.AddOrUpdate(percentRead.Key, 1, (key, oldValue) => oldValue + 1);
                    Console.WriteLine("{0},  {1} %, Thread Id= {2}", percentRead.Key, percentRead.Value, Thread.CurrentThread.ManagedThreadId);
                }
            );
            }
            else if (itemNumber == 3)
            {
                break;
            }
            else
            {
                Console.WriteLine("Вы ввели неопозанную команду!");
            }
        }
        static void Reading(string book)
        {
            int percent = 0;
            int prevPercent = 0;
            Task task = new Task(() =>
            {
                while (percent <= 100)
                {
                    percent++;
                    Thread.Sleep(1000);
                    _bookDictionary.TryUpdate(book, percent, prevPercent);
                    prevPercent = percent;
                }
                _bookDictionary.TryRemove(book, out percent);
            });
            task.Start();
        }

    }
}