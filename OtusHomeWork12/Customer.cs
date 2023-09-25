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
        public void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var addItem = e.NewItems[0] as Item;
                    Console.WriteLine($"Добавлен: {addItem.Name} с ID: {addItem.Id}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    var remItem = e.OldItems[0] as Item;
                    Console.WriteLine($"Удален: {remItem.Name} с ID: {remItem.Id}");
                    break;
            }
        }
    }
}
