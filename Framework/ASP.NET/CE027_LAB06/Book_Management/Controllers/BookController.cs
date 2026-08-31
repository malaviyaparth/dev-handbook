using Book_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Book_Management.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>
            {
                new Book { BookId = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Category = "Fiction", Price = 10.99, PublishedYear = 1925 },
                new Book { BookId = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Category = "Fiction", Price = 12.99, PublishedYear = 1960 },
                new Book { BookId = 3, Title = "1984", Author = "George Orwell", Category = "Dystopian", Price = 9.99, PublishedYear = 1949 },
                new Book { BookId = 4, Title = "A Brief History of Time", Author = "Stephen Hawking", Category = "Science", Price = 15.49, PublishedYear = 1988 },
                new Book { BookId = 5, Title = "Sapiens", Author = "Yuval Noah Harari", Category = "History", Price = 18.00, PublishedYear = 2011 },
                new Book { BookId = 6, Title = "The Hobbit", Author = "J.R.R. Tolkien", Category = "Fantasy", Price = 14.95, PublishedYear = 1937 },
                new Book { BookId = 7, Title = "Thinking, Fast and Slow", Author = "Daniel Kahneman", Category = "Psychology", Price = 16.99, PublishedYear = 2011 },
                new Book { BookId = 8, Title = "Clean Code", Author = "Robert C. Martin", Category = "Computers", Price = 39.99, PublishedYear = 2008 },
                new Book { BookId = 9, Title = "The Alchemist", Author = "Paulo Coelho", Category = "Fiction", Price = 11.50, PublishedYear = 1988 },
                new Book { BookId = 10, Title = "Educated", Author = "Tara Westover", Category = "Biography", Price = 13.20, PublishedYear = 2018 }
            };
        public IActionResult Index()
        {
            return View(books);
        }
        public IActionResult Details(int id)
        {
            Book? book = books.FirstOrDefault(b => b.BookId == id);
            if (book == null) return NotFound();

            return View("View", book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            books.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Book? book = books.FirstOrDefault(b => b.BookId == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book student)
        {
            int index = books.FindIndex(b => b.BookId == student.BookId);
            books[index] = student;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Book? book = books.FirstOrDefault(b => b.BookId == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Book? book = books.FirstOrDefault(b => b.BookId == id);

            if (book == null)
                return NotFound();

            books.Remove(book);

            return RedirectToAction("Index");
        }
    }
}
