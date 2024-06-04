using BookManager.Application.Comunication.Request.Loans;
using BookManager.Application.Comunication.Response.Loans;
using BookManger.Core.Entities;
using BookManger.Core.Repositories;

namespace BookManager.Application.Services.LoanServices;
public class LoanServices : ILoanServices
{
    private readonly ILoanRepository _loanRepository;

    public LoanServices(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public Task<int> AddAsync(RequestAddLoan request)
    {
        var loan = new Loan(request.UserId, request.BookId, request.ReturnDate);

        return _loanRepository.AddAsync(loan);
    }

    public async Task<ResponseGetAllLoansByBookId> GetAllByBookIdAsync(int id)
    {
        var loans = await _loanRepository.GetAllByBookIdAsync(id);

        if (!loans.Any())
        {
            throw new Exception($"No loan found with BookId = {id}");
        }

        var responses = new ResponseGetAllLoansByBookId();

        foreach (var loan in loans)
        {
            if (loan.User != null && loan.Book != null)
            {

                var response = new ResponseGetAllLoansByBookId.LoanByBookId()
                {
                    LoanId = loan.Id,
                    UserId = loan.UserId,
                    UserName = loan.User.Name,
                    LoanDate = loan.LoanDate,
                    ReturnDate = loan.ReturnDate,
                };

                responses.BookId = loan.BookId;
                responses.BookTitle = loan.Book.Title;
                responses.Loans.Add(response);
            }
        }

        return responses;
    }

    public async Task<ResponseGetAllLoansByUserId> GetAllByUserIdAsync(int id)
    {
        var loans = await _loanRepository.GetAllByUserIdAsync(id);

        if (!loans.Any())
        {
            throw new Exception($"No loan found with UserId = {id}");
        }

        var listResponses = new ResponseGetAllLoansByUserId();

        foreach (var loan in loans)
        {

            if (loan.Book != null && loan.User != null)
            {
                var response = new ResponseGetAllLoansByUserId.LoanByUserId()
                {
                    LoanId = loan.Id,
                    BookId = loan.BookId,
                    BookTitle = loan.Book.Title,
                    LoanDate = loan.LoanDate,
                    ReturnDate = loan.ReturnDate,
                };

                listResponses.UserId = loan.UserId;
                listResponses.UserName = loan.User.Name;
                listResponses.Loans.Add(response);
            }
        }

        return listResponses;
    }

    public async Task<ResponseGetLoanById> GetByIdAsync(int id)
    {
        var loan = await _loanRepository.GetByIdAsync(id);

        if (loan.Book != null && loan.User != null)
        {

            var response = new ResponseGetLoanById()
            {
                LoanId = loan.Id,
                UserId = loan.UserId,
                UserName = loan.User.Name,
                BookId = loan.Book.Id,
                BookTitle = loan.Book.Title,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate,
            };

            return response;
        }
        else
        {
            throw new KeyNotFoundException($"No Loan found with ID {id}");
        }
        
    }

    public async Task<ResponseReturnLoan> ReturnAsync(int id)
    {
        var loan = await _loanRepository.GetByIdAsync(id);
        var responseReturn = new ResponseReturnLoan();

        if (loan.ReturnDate < DateTime.Now)
        {
            var daysLate = (int)Math.Ceiling((DateTime.Now - loan.ReturnDate).TotalDays);

            responseReturn.IsReturnOnTime = $"A devolucao do livro esta atrasada em : {daysLate} dias";
        }

        else
        {
            responseReturn.IsReturnOnTime = "A devolucao esta em dia";
        }

        await _loanRepository.ReturnAsync(id);

        return responseReturn;

    }
}
