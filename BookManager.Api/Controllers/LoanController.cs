using BookManager.Application.Comunication.Request.Loans;
using BookManager.Application.Services.LoanServices;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class LoanController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id,
       [FromServices] ILoanServices loanServices)
    {
        var response = await loanServices.GetByIdAsync(id);

        return Ok(response);
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetAllByUserId(int id,
        [FromServices] ILoanServices loanServices)
    {
        var loans = await loanServices.GetAllByUserIdAsync(id);

        return Ok(loans);
    }

    [HttpGet("book/{id}")]
    public async Task<IActionResult> GetAllByBookId(int id,
      [FromServices] ILoanServices loanServices)
    {
        var loans = await loanServices.GetAllByBookIdAsync(id);

        return Ok(loans);
    }

    [HttpPost]
    public async Task<IActionResult> AddLoan(
        [FromServices] ILoanServices loanServices,
        [FromBody] RequestAddLoan requestAddLoan)
    {
        var response = await loanServices.AddAsync(requestAddLoan);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ReturnLoan(int id,
        [FromServices]ILoanServices loanServices)
    {
       var response = await loanServices.ReturnAsync(id);

        return Ok(response);
    }
        

}
