using Domain_.Abstract;
using Domain_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI_.Infrastructure;
using WebUI_.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository repository;
        public CartController(IBookRepository repo)
        {
            repository = repo;
            //ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }

        /*public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }*/

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart,int bookId, string returnUrl)
        {
            Book book = repository.Books
                .FirstOrDefault(b => b.Id == bookId);
            //Cart cart = null;

            if (book != null)
            {
                //cart = GetCart();
                cart.AddItem(book, 1);
            }

            return RedirectToAction("Index",  new {  returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int bookId, string returnUrl)
        {
            Book book = repository.Books
                .FirstOrDefault(b => b.Id == bookId);
            

            if (book != null)
            {
               cart.RemoveLine(book);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}
   
       
    