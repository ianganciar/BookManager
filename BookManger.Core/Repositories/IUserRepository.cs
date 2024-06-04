using BookManger.Core.Entities;

namespace BookManger.Core.Repositories;
public interface IUserRepository
{
    Task<int> AddAsync(User user);
    Task UpdateAsync(User user, int id);
    Task<User> GetAsync(int id);
    Task<List<User>> GetAllAsync();
    Task DeleteAsync(int id);

}
