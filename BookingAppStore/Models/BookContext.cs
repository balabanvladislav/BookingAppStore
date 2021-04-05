using System.Data.Entity;

namespace BookingAppStore.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }

    // umple cu date db, si sterge datele trecute
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book {Name = "First book ", Author = "Vladislav Balaban", Price = 100});
            db.Books.Add(new Book {Name = "War and Peace ", Author = "Lev Tolstoy", Price = 220});
            db.Books.Add(new Book {Name = "Do it", Author = "Noname Author", Price =50});
            
            
            base.Seed(db);
        }
    }
}