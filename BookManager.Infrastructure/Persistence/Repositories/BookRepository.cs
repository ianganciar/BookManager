using BookManger.Core.Entities;
using BookManger.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Persistence.Repositories;
public class BookRepository : IBookRepository
{
    private readonly BookManagerDbContext _dbContext;
    public BookRepository(BookManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddAsync(Book book)
    {
        await _dbContext.Books.AddAsync(book);

        await _dbContext.SaveChangesAsync();

        return book.Id;

    }

    public async Task DeleteAsync(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);

        if (book == null)
        {
            throw new KeyNotFoundException($"No book found with ID {id}");
        }

        _dbContext.Books.Remove(book);

        await _dbContext.SaveChangesAsync();

    }

    public async Task<List<Book>> GetAll()
    {
        return await _dbContext.Books.AsNoTracking().ToListAsync();

    }

    public async Task<Book> GetByIdAsync(int id)
    {
        var book = await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (book == null)
        {
            throw new KeyNotFoundException($"No book found with ID {id}");
        }

        return book;

    }

    public async Task UpdateAsync(int id, Book book)
    {
        var updateBook = await _dbContext.Books.FindAsync(id);

        if (updateBook == null)
        {
            throw new KeyNotFoundException($"No book found with ID {id}");
        }

        updateBook.Update(book.Title, book.Author, book.ISBN, book.PublicationYear);

        _dbContext.Books.Update(updateBook);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Book> IncreaseStockAsync(int id, int quantity)
    {
        var book = await _dbContext.Books.FindAsync(id);

        if (book == null)
        {
            throw new KeyNotFoundException($"No book found with ID {id}");
        }

        book.IncreaseStock(quantity);

        await _dbContext.SaveChangesAsync();

        return book;
    }

    public async Task<Book> DecreaseStockAsync(int id, int quantity)
    {
        var book = await _dbContext.Books.FindAsync(id);

        if (book == null)
        {
            throw new KeyNotFoundException($"No book found with ID {id}");
        }

        book.DecreaseStock(quantity);

        if (book.Stock <= 0)
        {
            book.DefaultStock();
        }

        await _dbContext.SaveChangesAsync();

        return book;
    }
}
