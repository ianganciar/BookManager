using BookManager.Application.Comunication.Request.Users;
using BookManager.Application.Services.BookServices;
using BookManager.Application.Services.UserSevices;
using BookManger.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddUser(
        [FromServices] IUserServices userServices,
        [FromBody] RequestAddUser request)
    {
        var user = await userServices.AddAsync(request);

        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id,
        [FromServices] IUserServices userServices,
        [FromBody] RequestUpdateUser request)
    {
        await userServices.UpdateAsync(request, id);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id,
        [FromServices] IUserServices userServices)
    {
        var user = await userServices.GetAsync(id);

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id,
       [FromServices] IUserServices userServices)
    {
        await userServices.DeleteAsync(id);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers(
       [FromServices] IUserServices userServices)
    {
        var response = await userServices.GetAllAsync();

        return Ok(response);
    }
}
