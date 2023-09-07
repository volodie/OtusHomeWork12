
namespace OtusHomeWork12_1
{
    internal class ReadFromConsole
    {
        public string ReadTextFromConsole()
        {
            string? symbol = Console.ReadLine().Trim().ToUpper();
            return symbol;
        }
        public int ReadNumbersFromConsole()
        {
            while (true)
            {
                string? number = Console.ReadLine();
                bool isNum = int.TryParse(number, out int n);
                if (isNum)
                {
                    if (n > 0)
                        return n;
                    else
                        Console.WriteLine("Введенный параметр должен быть больше 0!");
                }

                else
                {
                    Console.WriteLine("Для введенного параметра можно использовать только цифры!");
                }
            }
        }
    }
}
