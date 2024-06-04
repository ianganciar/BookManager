using BookManager.Application.Comunication.Request.Users;
using BookManager.Application.Comunication.Response.Users;
using BookManger.Core.Entities;
using BookManger.Core.Repositories;

namespace BookManager.Application.Services.UserSevices;
public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> AddAsync(RequestAddUser request)
    {
        var user = new User(request.Name, request.Email);

        return await _userRepository.AddAsync(user);
    }

    public async Task DeleteAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<List<ResponseGetUserById>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        var responses = new List<ResponseGetUserById>();

        foreach (var user in users)
        {
            var response = new ResponseGetUserById()
            {
                Name = user.Name,
                Email = user.Email,
            };
            responses.Add(response);
        }

        return responses;

    }

    public async Task<ResponseGetUserById> GetAsync(int id)
    {
        var user = await _userRepository.GetAsync(id);

        var responseUser = new ResponseGetUserById()
        {
            Email = user.Email,
            Name = user.Name,
        };

        return responseUser;
    }

    public async Task UpdateAsync(RequestUpdateUser request, int id)
    {
        var user = new User(request.Name, request.Email);

        await _userRepository.UpdateAsync(user, id);

    }

}


