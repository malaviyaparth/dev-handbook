using Book_Management.Models;

namespace Book_Management_2.Repositories
{
    public class BookRepository : IBookRepository
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
        public BookRepository() { }

        public void Add(Book book)
        {
            book.BookId = books.Any() ? books.Max(b => b.BookId) + 1 : 1;
            books.Add(book);
        }

        public void Delete(int id)
        {
            Book? book = GetById(id);
            if (book != null)
            {
                books.Remove(book);
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        public Book? GetById(int id)
        {
            return books.FirstOrDefault(b => b.BookId == id);
        }

        public void Update(Book book)
        {
            int index = books.FindIndex(b => b.BookId == book.BookId);
            if (index != -1)
            {
                books[index] = book;
            }
        }
    }
}
