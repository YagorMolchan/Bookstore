using BookStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.PageModel
{
    public class CartIndexModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}