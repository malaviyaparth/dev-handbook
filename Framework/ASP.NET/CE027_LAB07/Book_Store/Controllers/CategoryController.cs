using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class CategoryController : Controller
    {
        // Shared data with BookController (in-memory storage)
        private static List<Category> _categories = new()
        {
            new Category { Id = 1, Name = "Fiction", Description = "Classic and modern fiction novels" },
            new Category { Id = 2, Name = "Science Fiction", Description = "Science fiction and futuristic stories" },
            new Category { Id = 3, Name = "Mystery", Description = "Mystery and thriller novels" },
            new Category { Id = 4, Name = "Romance", Description = "Romantic novels and love stories" },
            new Category { Id = 5, Name = "Children", Description = "Stories and books for children" },
            new Category { Id = 6, Name = "Non-Fiction", Description = "Educational and informative books" }
        };

        private static List<Book> _books = GetSampleBooks();

        public IActionResult Index()
        {
            return View(_categories);
        }

        public IActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            // Get books in this category
            var booksInCategory = _books.Where(b => b.Category == category.Name).ToList();

            ViewBag.Category = category;
            return View(booksInCategory);
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
                    Description = "A classic American novel set in the Jazz Age, exploring themes of wealth, love, and the American Dream.",
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
                    Description = "A gripping tale of racial injustice and childhood innocence in the Deep South.",
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
                    Description = "A timeless tale of love and social commentary featuring Elizabeth Bennet and Mr. Darcy.",
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
                    Description = "An epic science fiction novel about politics, religion, and ecology on the desert planet Arrakis.",
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
                    Description = "A dark dystopian novel depicting a totalitarian society and exploring themes of surveillance and control.",
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
                    Description = "A classic mystery novel featuring detective Hercule Poirot solving the murder of Roger Ackroyd.",
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
                    Description = "A thrilling mystery involving a journalist and hacker investigating a decades-old disappearance.",
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
                    Description = "A classic Gothic romance following Jane Eyre, an orphaned girl seeking love and independence.",
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
                    Description = "A touching modern romance spanning decades, telling the story of Noah and Allie.",
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
                    Description = "A magical adventure where children discover a fantastical world through a wardrobe.",
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
                    Description = "A heartwarming tale of friendship between a pig named Wilbur and Charlotte the spider.",
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
                    Description = "An ambitious exploration of human history from the Stone Age to modern times.",
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
                    Description = "A groundbreaking exploration of the two systems of thought and human decision making.",
                    Price = 380m,
                    Rating = 4.5,
                    Publisher = "Farrar, Straus and Giroux",
                    PublishedYear = 2020
                }
            };
        }
    }
}
