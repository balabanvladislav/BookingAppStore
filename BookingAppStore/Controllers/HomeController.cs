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
            ViewBag.Books = books;
            // intoarcem vizualizarea
            return View();
        }

        [HttpGet] // cand accesam saitul buy
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost] // cand trimitem formularul
        public string Buy(Purchase purchase)
        {
            if (purchase.Person is null || purchase.Address is null)
            {
                return "<h1 position=\"center\">Ati introdus gresit datele!</h1></br>" +
                       "<a href=\"http://localhost:5000/Home/Buy/1\">Din nou</a>";
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

                return "Multumim," + purchase.Person + " pentru cumparatura!";
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public string Add(Book book)
        {
            Console.WriteLine(book.Author);
            Console.WriteLine(book.Name);
            db.Books.Add(book);
            db.SaveChanges();
            return "Adaugat cu succes!";
        }
    }
}