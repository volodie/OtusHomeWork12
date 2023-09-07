using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace OtusHomeWork12
{
    internal class Shop 
    {
        public class DeleteFromCollection : Exception
        { 
            public DeleteFromCollection(string message) : base(message) { }
        }
        public void Add(ObservableCollection<Item> itemL, Item item)
        {
           itemL.Add(item);
        }
        public void Remove(ObservableCollection<Item> itemL, int itNumber)
        {
            try
            {
                itemL.RemoveAt(itNumber);
            }
            catch (Exception)
            {
                var ue = new DeleteFromCollection($"Вы указали не верный номер товара для удаления!");
                throw ue;
            }
            
        }
    }
   
    
}
