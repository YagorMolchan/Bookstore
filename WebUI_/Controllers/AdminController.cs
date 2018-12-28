using Domain_.Abstract;
using Domain_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI_.Controllers
{
    public class AdminController : Controller
    {
        IBookRepository bookRepository;

        public AdminController(IBookRepository repo)
        {
            bookRepository = repo;
        }

        public ViewResult Index()
        {
            return View(bookRepository.Books);
        }

        public ViewResult Edit(int id)
        {
            Book book = bookRepository.Books.FirstOrDefault(b => b.Id == id);
            return View(book);
        }
    }
}