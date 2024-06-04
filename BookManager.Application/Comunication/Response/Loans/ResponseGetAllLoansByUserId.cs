namespace BookManager.Application.Comunication.Response.Loans;
public class ResponseGetAllLoansByUserId
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public List<LoanByUserId> Loans { get; set; } = new List<LoanByUserId>();

    public class LoanByUserId
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}

