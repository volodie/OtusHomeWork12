
using System.Collections.Concurrent;


namespace OtusHomeWork12_1
{
    internal class Library
    {
        private readonly ConcurrentDictionary<string, int> _library;
        public Library(ConcurrentDictionary<string, int> library)
        {
            _library = library ?? throw new ArgumentNullException(nameof(library));
        }
        public void AddBook(string bookName)
        {
            if (!_library.ContainsKey(bookName))
            {
                _library.TryAdd(bookName, 0);
            }
        }

        public void ShowBookList()
        {
            foreach (var bookPair in _library)
            {
                Console.WriteLine($"{bookPair.Key} - {bookPair.Value}%");
            }
        }

        public void Read()
        {
            if (_library.IsEmpty)
            {
                return;
            }
            foreach (var book in _library)
            {
                if (book.Value < 100)
                {
                    _library.TryUpdate(book.Key, book.Value + 1, book.Value);
                }
                else
                {
                    _library.TryRemove(book);
                }
            }
            Thread.Sleep(1000);
        }
    }
}
