using BookManger.Core.Entities;

namespace BookManager.Application.Comunication.Request.Users;

public class RequestAddUser
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}