using BookManger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookManager.Infrastructure.Persistence;
public class BookManagerDbContext : DbContext
{
    public BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
