using System.Transactions;
using static System.Reflection.Metadata.BlobBuilder;

class Program
{

    static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\n===== Library Management =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Register Member");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. View Available Books");
            Console.WriteLine("6. Exit");

            Console.Write("Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Book b = new Book();

                    Console.Write("Book ID: ");
                    b.BookId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Title: ");
                    b.Title = Console.ReadLine();

                    Console.Write("Author: ");
                    b.Author = Console.ReadLine();

                    b.IsAvailable = true;

                    library.AddBook(b);

                    break;

                case 2:
                    Member m = new Member();

                    Console.Write("Member ID: ");
                    m.Id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name: ");
                    m.Name = Console.ReadLine();

                    library.RegisterMember(m);

                    break;

                case 3:
                    Console.Write("Book ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    if (library.Members.Count > 0)
                    {
                        library.BorrowBook(id, library.Members[0]);
                    }

                    break;

                case 4:
                    Console.Write("Book ID: ");
                    library.ReturnBook(Convert.ToInt32(Console.ReadLine()));
                    break;

                case 5:
                    library.ViewBooks();
                    break;

                case 6:
                    return;
            }
        }
    }
}