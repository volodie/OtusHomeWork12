using System.Collections.Concurrent;
using OtusHomeWork12_1;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
       
        var library = new ConcurrentDictionary<string, int>();
        var librarian = new Library(library);
        var consoleService = new ConsolePrintingMenu(librarian);
        var readService = new ReadLibrary(librarian);
        Thread myNewThread = new Thread(consoleService.Print);

        Parallel.Invoke(() =>
        {
            while (myNewThread.IsAlive)
            {
                readService.StartReading();
            }
        }, myNewThread.Start
        );
    }
}