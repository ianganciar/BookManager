using BookManger.Core.Entities;
using BookManger.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly BookManagerDbContext _dbContext;

    public UserRepository(BookManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);

        if (user == null)
        {
            throw new KeyNotFoundException($"No User found with ID {id}");
        }

        _dbContext.Remove(user);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllAsync()
    {
      return await _dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User> GetAsync(int id)
    {
        var user = await _dbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        if (user == null)
        {
            throw new KeyNotFoundException($"No User found with ID {id}");
        }

        return user;
    }

    public async Task UpdateAsync(User user, int id)
    {
        var updateUser = await _dbContext.Users.FindAsync(id);

        if (updateUser == null)
        {
            throw new KeyNotFoundException($"No User found with ID {id}");
        }

        updateUser.Update(user.Name, user.Email);

        _dbContext.Users.Update(updateUser);

        await _dbContext.SaveChangesAsync();

    }
}
