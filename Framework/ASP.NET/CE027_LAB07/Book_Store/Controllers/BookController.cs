using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> _books = GetSampleBooks();
        private static List<Category> _categories = GetSampleCategories();
        private static int _nextId = 14;

        public IActionResult Index(string? category = null)
        {
            var books = _books;

            if (!string.IsNullOrEmpty(category))
            {
                books = books.Where(b => b.Category == category).ToList();
                ViewBag.SelectedCategory = category;
            }

            ViewBag.Categories = _categories.Select(c => c.Name).Distinct().ToList();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categories.Select(c => c.Name).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = _nextId++;
                _books.Add(book);
                return RedirectToAction(nameof(Details), new { id = book.Id });
            }

            ViewBag.Categories = _categories.Select(c => c.Name).ToList();
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            ViewBag.Categories = _categories.Select(c => c.Name).ToList();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingBook = _books.FirstOrDefault(b => b.Id == id);
                if (existingBook == null)
                    return NotFound();

                existingBook.Name = book.Name;
                existingBook.Author = book.Author;
                existingBook.Category = book.Category;
                existingBook.Description = book.Description;
                existingBook.Price = book.Price;
                existingBook.Rating = book.Rating;
                existingBook.Publisher = book.Publisher;
                existingBook.PublishedYear = book.PublishedYear;

                return RedirectToAction(nameof(Details), new { id = book.Id });
            }

            ViewBag.Categories = _categories.Select(c => c.Name).ToList();
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }

            return RedirectToAction(nameof(Index));
        }

        private static List<Book> GetSampleBooks()
        {
            return new()
            {
                // Fiction
                new Book
                {
                    Id = 1,
                    Name = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Category = "Fiction",
                    Description = "A classic American novel set in the Jazz Age, exploring themes of wealth, love, and the American Dream through the eyes of Nick Carraway.",
                    Price = 299m,
                    Rating = 4.8,
                    Publisher = "Penguin Classics",
                    PublishedYear = 2021
                },
                new Book
                {
                    Id = 2,
                    Name = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Category = "Fiction",
                    Description = "A gripping tale of racial injustice and childhood innocence, set in the Deep South during the Great Depression.",
                    Price = 350m,
                    Rating = 4.9,
                    Publisher = "Harper Perennial",
                    PublishedYear = 2018
                },
                new Book
                {
                    Id = 3,
                    Name = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Category = "Fiction",
                    Description = "A timeless tale of love and social commentary featuring Elizabeth Bennet and the proud Mr. Darcy in Georgian England.",
                    Price = 250m,
                    Rating = 4.7,
                    Publisher = "Penguin Books",
                    PublishedYear = 2017
                },

                // Science Fiction
                new Book
                {
                    Id = 4,
                    Name = "Dune",
                    Author = "Frank Herbert",
                    Category = "Science Fiction",
                    Description = "An epic science fiction novel about politics, religion, and ecology on the desert planet Arrakis, featuring the young hero Paul Atreides.",
                    Price = 399m,
                    Rating = 4.5,
                    Publisher = "Ace Books",
                    PublishedYear = 2019
                },
                new Book
                {
                    Id = 5,
                    Name = "1984",
                    Author = "George Orwell",
                    Category = "Science Fiction",
                    Description = "A dark dystopian novel depicting a totalitarian society and exploring themes of surveillance, control, and individual freedom.",
                    Price = 320m,
                    Rating = 4.6,
                    Publisher = "Penguin Classics",
                    PublishedYear = 2020
                },

                // Mystery
                new Book
                {
                    Id = 6,
                    Name = "The Murder of Roger Ackroyd",
                    Author = "Agatha Christie",
                    Category = "Mystery",
                    Description = "A classic mystery novel featuring detective Hercule Poirot solving the murder of the wealthy industrialist Roger Ackroyd.",
                    Price = 280m,
                    Rating = 4.6,
                    Publisher = "Collins Crime Club",
                    PublishedYear = 2019
                },
                new Book
                {
                    Id = 7,
                    Name = "The Girl with the Dragon Tattoo",
                    Author = "Stieg Larsson",
                    Category = "Mystery",
                    Description = "A thrilling mystery involving a journalist and a brilliant hacker investigating a decades-old disappearance on a Swedish island.",
                    Price = 380m,
                    Rating = 4.5,
                    Publisher = "MacLehose Press",
                    PublishedYear = 2018
                },

                // Romance
                new Book
                {
                    Id = 8,
                    Name = "Jane Eyre",
                    Author = "Charlotte Brontë",
                    Category = "Romance",
                    Description = "A classic Gothic romance following Jane Eyre, an orphaned girl who becomes a strong-willed woman seeking love and independence.",
                    Price = 275m,
                    Rating = 4.8,
                    Publisher = "Penguin Classics",
                    PublishedYear = 2016
                },
                new Book
                {
                    Id = 9,
                    Name = "The Notebook",
                    Author = "Nicholas Sparks",
                    Category = "Romance",
                    Description = "A touching modern romance spanning decades, telling the story of Noah and Allie as they face social obstacles and time itself.",
                    Price = 300m,
                    Rating = 4.4,
                    Publisher = "Warner Books",
                    PublishedYear = 2019
                },

                // Children
                new Book
                {
                    Id = 10,
                    Name = "The Lion, the Witch and the Wardrobe",
                    Author = "C.S. Lewis",
                    Category = "Children",
                    Description = "A magical adventure where children discover a fantastical world through a wardrobe, featuring battles between good and evil.",
                    Price = 220m,
                    Rating = 4.9,
                    Publisher = "HarperCollins",
                    PublishedYear = 2020
                },
                new Book
                {
                    Id = 11,
                    Name = "Charlotte's Web",
                    Author = "E.B. White",
                    Category = "Children",
                    Description = "A heartwarming tale of friendship between a pig named Wilbur and Charlotte the spider who saves his life with her web.",
                    Price = 200m,
                    Rating = 4.9,
                    Publisher = "Harper and Row",
                    PublishedYear = 2017
                },

                // Non-Fiction
                new Book
                {
                    Id = 12,
                    Name = "Sapiens",
                    Author = "Yuval Noah Harari",
                    Category = "Non-Fiction",
                    Description = "An ambitious exploration of human history from the Stone Age to modern times, examining how Homo sapiens came to dominate the world.",
                    Price = 450m,
                    Rating = 4.6,
                    Publisher = "Penguin Books",
                    PublishedYear = 2021
                },
                new Book
                {
                    Id = 13,
                    Name = "Thinking, Fast and Slow",
                    Author = "Daniel Kahneman",
                    Category = "Non-Fiction",
                    Description = "A groundbreaking exploration of the two systems of thought: the fast, automatic system and the slow, deliberate system.",
                    Price = 380m,
                    Rating = 4.5,
                    Publisher = "Farrar, Straus and Giroux",
                    PublishedYear = 2020
                }
            };
        }

        private static List<Category> GetSampleCategories()
        {
            return new()
            {
                new Category { Id = 1, Name = "Fiction", Description = "Classic and modern fiction novels" },
                new Category { Id = 2, Name = "Science Fiction", Description = "Science fiction and futuristic stories" },
                new Category { Id = 3, Name = "Mystery", Description = "Mystery and thriller novels" },
                new Category { Id = 4, Name = "Romance", Description = "Romantic novels and love stories" },
                new Category { Id = 5, Name = "Children", Description = "Stories and books for children" },
                new Category { Id = 6, Name = "Non-Fiction", Description = "Educational and informative books" }
            };
        }
    }
}
