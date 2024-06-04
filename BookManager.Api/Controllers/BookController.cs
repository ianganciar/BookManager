using BookManager.Application.Comunication.Request.Books;
using BookManager.Application.Services.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IBookServices bookServices)
    {
        var response = await bookServices.GetAll();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id,
        [FromServices] IBookServices bookServices)
    {
        var response = await bookServices.GetByIdAsync(id);

        return Ok(response);

    }

    [HttpPost]
    public async Task<IActionResult> AddBook(
        [FromServices] IBookServices bookServices,
        [FromBody] RequestAddBook request)
    {
        await bookServices.AddAsync(request);

        return NoContent();

    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateBook(int id,
        [FromServices] IBookServices bookServices,
        [FromBody] RequestUpdateBook request)
    {
        await bookServices.UpdateAsync(request, id);

        return NoContent();
    }

    [HttpPut("increase-stock/{id}")]
    public async Task<IActionResult> IncreaseStock(int id,
        [FromServices] IBookServices bookServices,
        [FromBody] RequestIncreaseBookStock request)
    {
        var response = await bookServices.IncreaseStockAsync(id, request);

        return Ok(response);
    }

    [HttpPut("decrease-stock/{id}")]
    public async Task<IActionResult> DecreaseStock(int id,
        [FromServices] IBookServices bookServices,
        [FromBody] RequestDecreaseBookStock request)
    {
        var response = await bookServices.DecreaseStockAsync(id, request);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id,
        [FromServices] IBookServices bookServices)
    {
        await bookServices.DeleteAsync(id);

        return NoContent();
    }

}
