using BookManager.Application.Comunication.Request.Books;
using BookManager.Application.Comunication.Response.Books;
using BookManger.Core.Entities;
using BookManger.Core.Repositories;

namespace BookManager.Application.Services.BookServices;
public class BookServices : IBookServices
{
    private readonly IBookRepository _bookRepository;

    public BookServices(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<int> AddAsync(RequestAddBook request)
    {
        var book = new Book(request.Title, request.Author, request.ISBN, request.PublicationYear, request.Stock);

        return await _bookRepository.AddAsync(book);
    }

    public async Task<ResponseDecreaseBookStock> DecreaseStockAsync(int id, RequestDecreaseBookStock request)
    {
        var book = await _bookRepository.DecreaseStockAsync(id, request.Quantity);

        var response = new ResponseDecreaseBookStock()
        {
            Quantity = book.Stock
        };

        return response;
    }

    public async Task DeleteAsync(int id)
    {
        await _bookRepository.DeleteAsync(id);
    }

    public async Task<List<ResponseGetBookById>> GetAll()
    {
        var books = await _bookRepository.GetAll();
        var responses = new List<ResponseGetBookById>();

        foreach (var book in books)
        {
            var response = new ResponseGetBookById
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,
                Stock = book.Stock
            };

            responses.Add(response);
        }

        return responses;
    }

    public async Task<ResponseGetBookById> GetByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        var response = new ResponseGetBookById
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            PublicationYear = book.PublicationYear,
            Stock = book.Stock
        };

        return response;
    }

    public async Task<ResponseIncreaseBookStock> IncreaseStockAsync(int id, RequestIncreaseBookStock request)
    {

        var book = await _bookRepository.IncreaseStockAsync(id, request.Quantity);

        var response = new ResponseIncreaseBookStock()
        {
            Quantity = book.Stock
        };

        return response;
    }

    public async Task UpdateAsync(RequestUpdateBook request, int id)
    {
        var book = new Book(request.Title, request.Author, request.ISBN, request.PublicationYear);

        book.Update(request.Title, request.Author, request.ISBN, request.PublicationYear);

        await _bookRepository.UpdateAsync(id, book);
    }
}
