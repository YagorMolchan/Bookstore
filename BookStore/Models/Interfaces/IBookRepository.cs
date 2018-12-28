using BookStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        void SaveBook(Book book);
    }
}
