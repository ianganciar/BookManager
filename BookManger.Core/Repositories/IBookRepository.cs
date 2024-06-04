using BookManger.Core.Entities;

namespace BookManger.Core.Repositories;
public interface IBookRepository
{
    Task<List<Book>> GetAll();

    Task<int> AddAsync(Book book);

    Task<Book> GetByIdAsync(int id);

    Task UpdateAsync(int id, Book book);

    Task<Book> IncreaseStockAsync(int id, int quantity);
    Task<Book> DecreaseStockAsync(int id, int quantity);
    Task DeleteAsync(int id);
}
