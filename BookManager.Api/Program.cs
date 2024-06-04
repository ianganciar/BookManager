using BookManager.Application.Services.BookServices;
using BookManager.Application.Services.LoanServices;
using BookManager.Application.Services.UserSevices;
using BookManager.Infrastructure.Persistence;
using BookManager.Infrastructure.Persistence.Repositories;
using BookManger.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext config
var connectionString = builder.Configuration.GetConnectionString("ConnectionSqlServer");
builder.Services.AddDbContext<BookManagerDbContext>(options => options.UseSqlServer(connectionString));

//Dependency Injection

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ILoanServices, LoanServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
