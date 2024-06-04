namespace BookManger.Core.Entities;
public class Loan : BaseEntity

{
    public Loan(int userId, int bookId, DateTime returnDate)
    {
        UserId = userId;
        BookId = bookId;
        ReturnDate = returnDate;
    }

    public int UserId { get; private set; }
    public User? User { get; private set; } 
    public int BookId { get; private set; }
    public Book? Book { get; private set; }
    public DateTime LoanDate { get; private set; } = DateTime.Now;
    public DateTime ReturnDate { get; private set; }
}
