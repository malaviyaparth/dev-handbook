using System;

class Transaction
{
    public Book Book { get; set; }
    public Member Member { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}