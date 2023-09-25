using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork12_1
{
    internal class ReadLibrary
    {
        private readonly Library _librarian;

        public ReadLibrary(Library librarian)
        {
            _librarian = librarian ?? throw new ArgumentNullException(nameof(librarian));
        }

        public void StartReading()
        {
            _librarian.Read();
        }
    }
}
