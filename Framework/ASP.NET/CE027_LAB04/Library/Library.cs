class Library
{
    public List<Book> Books = new List<Book>();
    public List<Member> Members = new List<Member>();
    public List<Transaction> Transactions = new List<Transaction>();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RegisterMember(Member member)
    {
        Members.Add(member);
    }

    public void BorrowBook(int bookId, Member member)
    {
        foreach (Book book in Books)
        {
            if (book.BookId == bookId && book.IsAvailable)
            {
                book.IsAvailable = false;

                Transactions.Add(new Transaction
                {
                    Book = book,
                    Member = member,
                    BorrowDate = DateTime.Now
                });

                Console.WriteLine("Book Borrowed Successfully");
                return;
            }
        }

        Console.WriteLine("Book Not Available");
    }

    public void ReturnBook(int bookId)
    {
        foreach (Transaction t in Transactions)
        {
            if (t.Book.BookId == bookId && t.ReturnDate == null)
            {
                t.Book.IsAvailable = true;
                t.ReturnDate = DateTime.Now;

                Console.WriteLine("Book Returned Successfully");
                return;
            }
        }

        Console.WriteLine("Book was not borrowed");
    }

    public void ViewBooks()
    {
        foreach (Book book in Books)
        {
            if (book.IsAvailable)
            {
                Console.WriteLine($"{book.BookId} - {book.Title} by {book.Author}");
            }
        }
    }
}