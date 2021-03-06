using System;
using System.Web.Mvc;
using BookingAppStore.Models;

namespace BookingAppStore.Controllers
{
    public class HomeController : Controller
    {
        private BookContext db = new BookContext();

        public ActionResult Index()
        {
            // primi din BD toate obiectele Book
            var books = db.Books;
            // transmitem toate obiectele in proprietatea dinamica Books in ViewBag
            // ViewBag.Books = books;
            // intoarcem vizualizarea
            
            return View(books);
        }
         

        [HttpGet] // cand accesam saitul buy
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost] // cand trimitem formularul
        public ActionResult Buy(Purchase purchase)
        {
            if (purchase.Person is null || purchase.Address is null)
            {
                return Index();
            }
            else
            {
                Console.WriteLine(purchase.Address);
                Console.WriteLine(purchase.Date);
                Console.WriteLine(purchase.Person);
                purchase.Date = DateTime.Now;
                // adaugam informatia despre cumparatura in baza de date
                db.Purchases.Add(purchase);
                // salvam schimbarile
                db.SaveChanges();

                return Index();
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            Console.WriteLine(book.Author);
            Console.WriteLine(book.Name);
            db.Books.Add(book);
            db.SaveChanges();
            return Content("Adaugat cu succes");
        }
    }
}