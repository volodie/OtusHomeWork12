using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork12
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
