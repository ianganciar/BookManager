using BookManger.Core.Entities;

namespace BookManager.Application.Comunication.Request.Loans;

public class RequestAddLoan
{
    public int UserId { get; set; }

    public int BookId { get; set; }

    public DateTime ReturnDate { get; set; }
}