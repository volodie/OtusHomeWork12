using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork12_1
{
    internal class ConsolePrintingMenu
    {
        ReadFromConsole readParametr = new ReadFromConsole();
        private readonly Library _librarian;

        public ConsolePrintingMenu(Library librarian)
        {
            _librarian = librarian ?? throw new ArgumentNullException(nameof(librarian));
        }
        public void Print() 
        {
            while (true)
            {
                Console.WriteLine("Вас привествует Библиотека. Введите 1 - добавить книгу, 2 - вывести список непрочитанного, 3 - выйти.");
                var itemNumber = readParametr.ReadNumbersFromConsole();
                if (itemNumber == 1)
                {
                    Console.WriteLine("Введите название книги:");
                    var bookName = readParametr.ReadTextFromConsole();
                    _librarian.AddBook(bookName);
                }
                else if (itemNumber == 2)
                {
                    _librarian.ShowBookList();
                }

                else if (itemNumber == 3)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Вы ввели неопозанную команду!");
                }
            }
        }
    }
}
