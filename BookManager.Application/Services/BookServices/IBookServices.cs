using BookManager.Application.Comunication.Request;
using BookManager.Application.Comunication.Request.Books;
using BookManager.Application.Comunication.Response.Books;
using BookManger.Core.Entities;
namespace BookManager.Application.Services.BookServices;

public interface IBookServices
{
    Task<int> AddAsync(RequestAddBook request);

    Task<List<ResponseGetBookById>> GetAll();

    Task<ResponseGetBookById> GetByIdAsync(int id);

    Task UpdateAsync(RequestUpdateBook request, int id);

    Task<ResponseIncreaseBookStock> IncreaseStockAsync(int id,RequestIncreaseBookStock request);

    Task<ResponseDecreaseBookStock> DecreaseStockAsync(int id, RequestDecreaseBookStock request);

    Task DeleteAsync(int id);

}