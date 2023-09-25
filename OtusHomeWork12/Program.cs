using System.Collections.ObjectModel;
using OtusHomeWork12;

internal class Program
{
    private static void Main(string[] args)
    {
        ReadFromConsole readParametr = new ReadFromConsole();
        var shop = new Shop();
        shop.AddCustomer(new Customer());
        var count = 1;

        var i = 0;
        while (true)
        {
            Console.WriteLine("Вас привествует Магазин. Введите A - для добавления товара, D - для удаления товара, X - для выхода из магазина.");
            var enteredChar = readParametr.ReadTextFromConsole();
            if (string.IsNullOrEmpty(enteredChar))
            {
                break;
            }
            else if (enteredChar == "A")
            {
                Console.CursorLeft = 0;
                shop.Add(new Item() { Id = count, Name = $"Товар от {DateTime.Now}" });
                count++;

            }
            else if (enteredChar == "D")
            {
                Console.WriteLine("Какой номер товара вы хотите удалить? Введите номер товара: ");
                Console.CursorLeft = 0;
                int id;
                while (true)
                {
                    var isID = int.TryParse(Console.ReadLine(), out id);
                    if (isID)
                    {
                        shop.Remove(id);
                        break;
                    }
                    else Console.WriteLine("ID - целое число");
                }
            }
            else if (enteredChar == "X")
            {
                break;
            }
            else 
            {
                Console.WriteLine("Вы ввели неопозанную команду!");
            }
        }
    }
}