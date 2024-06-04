using BookManger.Core.Entities;

namespace BookManger.Core.Repositories;
public interface ILoanRepository
{
    Task<List<Loan>> GetAllByUserIdAsync(int id);
    Task<List<Loan>> GetAllByBookIdAsync(int id);
    Task<int> AddAsync(Loan loan);

    Task ReturnAsync(int id);

    Task<Loan> GetByIdAsync(int id);
}
