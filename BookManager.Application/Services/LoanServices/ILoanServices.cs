using BookManager.Application.Comunication.Request.Loans;
using BookManager.Application.Comunication.Response.Loans;
using BookManger.Core.Entities;

namespace BookManager.Application.Services.LoanServices;

public interface ILoanServices
{
    Task<int> AddAsync(RequestAddLoan request);

    Task<ResponseGetLoanById> GetByIdAsync(int id);

    Task<ResponseGetAllLoansByUserId> GetAllByUserIdAsync(int id);

    Task<ResponseGetAllLoansByBookId> GetAllByBookIdAsync(int id);

    Task<ResponseReturnLoan> ReturnAsync(int id);
}