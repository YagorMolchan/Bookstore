﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddItem(Book book, int quantity)
        {
            CartLine line = lineCollection
                .Where(b => b.Book.Id == book.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Book = book, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Book book)
        {
            lineCollection.RemoveAll(l => l.Book.Id == book.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Book.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }

    public class CartLine
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}