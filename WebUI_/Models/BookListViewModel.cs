using Domain_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI_.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}