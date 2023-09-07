using System.Collections.ObjectModel;
using OtusHomeWork12;

internal class Program
{
    private static void Main(string[] args)
    {
        ReadFromConsole readParametr = new ReadFromConsole();
        var itemList = new ObservableCollection<Item>();
        
        var shop = new Shop();
        var customer = new Customer("Alice");
        itemList.CollectionChanged += customer.OnItemChanged;
        var customer1 = new Customer("Bruce");
        itemList.CollectionChanged += customer1.OnItemChanged;
        var customer2 = new Customer("Peter");
        itemList.CollectionChanged += customer1.OnItemChanged;

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
                i ++;
                var item = new Item();
                item.Id = i;
                item.Name = "товар от " + DateTime.Now.ToString();
                shop.Add(itemList, item);
               
            }
            else if (enteredChar == "D")
            {
                Console.WriteLine("Какой номер товара вы хотите удалить? Введите номер товара: ");
                var itemNumber = readParametr.ReadNumbersFromConsole();

                try
                {
                    shop.Remove(itemList, itemNumber);
                }
                catch (Exception ex)
                {
                    string mes = ex.Message;
                    Console.WriteLine(mes);
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