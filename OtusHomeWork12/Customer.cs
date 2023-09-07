using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork12
{
    internal class Customer
    {
        public readonly string _customerName;
        public Customer(string customerName)
        {
            _customerName = customerName;
        }
        public void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var addItem = e.NewItems[0] as Item;
                    Console.WriteLine($"Покупатель {_customerName} Добавлен товар: {addItem.Id}  с наименованием {addItem.Name}.");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    var delItem = e.OldItems[0] as Item;
                    Console.WriteLine($"Покупатель {_customerName} удален товар: {delItem.Id}  с наименованием {delItem.Name}.");
                    break;
            }
        }
    }
}
