class Book
{
    private int bookId;
    private string title;
    private string author;
    private bool isAvailable;

    public int BookId
    {
        get { return bookId; }
        set { bookId = value; }
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public bool IsAvailable
    {
        get { return isAvailable; }
        set { isAvailable = value; }
    }
}