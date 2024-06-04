using BookManager.Application.Comunication.Request.Users;
using BookManager.Application.Comunication.Response.Users;

namespace BookManager.Application.Services.UserSevices;
public interface IUserServices
{
    Task<int> AddAsync(RequestAddUser request);

    Task UpdateAsync(RequestUpdateUser request, int id);

    Task<ResponseGetUserById> GetAsync(int id);
    Task<List<ResponseGetUserById>> GetAllAsync();
    Task DeleteAsync(int id);

}
