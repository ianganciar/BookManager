using BookManger.Core.Entities;
using BookManger.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Persistence.Repositories;
public class LoanRepository : ILoanRepository
{
    private readonly BookManagerDbContext _dbContext;

    public LoanRepository(BookManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddAsync(Loan loan)
    {
        var book = await _dbContext.Books.FindAsync(loan.BookId);

        if (book == null)
        {
            throw new KeyNotFoundException($"No book found with ID {loan.BookId}");
        }

        if (book.Stock > 0)
        {
            book.DecreaseStock(1);
            await _dbContext.Loans.AddAsync(loan);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("There are not enough books in stock.");
        }

        return loan.Id;
    }

    public async Task<List<Loan>> GetAllByBookIdAsync(int id)
    {
        var loans = await _dbContext.Loans
           .Include(b => b.Book)
           .Include(u => u.User)
           .Where(l => l.BookId == id)
           .AsNoTracking()
           .ToListAsync();

        return loans;
    }

    public async Task<List<Loan>> GetAllByUserIdAsync(int id)
    {
        var loans = await _dbContext.Loans
            .Include(b => b.Book)
            .Include(u => u.User)
            .Where(l => l.UserId == id)
            .AsNoTracking()
            .ToListAsync();

        return loans;
    }

    public async Task<Loan> GetByIdAsync(int id)
    {
        var loan = await _dbContext.Loans.Include(u => u.User).Include(b => b.Book).FirstOrDefaultAsync(l => l.Id == id);

        if (loan == null)
        {
            throw new KeyNotFoundException($"No Loan found with ID {id}");
        }

        return loan;
    }

    public async Task ReturnAsync(int id)
    {

        var loan = await _dbContext.Loans.Include(b => b.Book).FirstOrDefaultAsync(l => l.Id == id);

        if (loan == null || loan.Book == null)
        {
            throw new KeyNotFoundException($"No Loan found with ID {id}");
        }

        loan.Book.IncreaseStock(1);

        _dbContext.Loans.Remove(loan);

        await _dbContext.SaveChangesAsync();

    }
}
