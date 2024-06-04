using BookManger.Core.Entities;

namespace BookManager.Application.Comunication.Response.Loans;
public class ResponseGetLoanById
{
    public int LoanId { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;   
    public int BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }

}
