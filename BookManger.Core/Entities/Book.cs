using System.Globalization;

namespace BookManger.Core.Entities;
public class Book : BaseEntity
{

    public Book(string title, string author, string iSBN, int publicationYear, int stock)
    {
        Title = title;
        Author = author;
        ISBN = iSBN;
        PublicationYear = publicationYear;
        Stock = stock;
    }

    public Book(string title, string author, string iSBN, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = iSBN;
        PublicationYear = publicationYear;
    }

    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int PublicationYear { get; private set; }
    public int Stock { get; private set; } 
    public List<Loan> Loans { get; private set; } = new List<Loan>();

    public void IncreaseStock(int quantity)
    {
        Stock += quantity;
    }

    public void DecreaseStock(int quantity)
    {
        Stock -= quantity;
    }

    public void DefaultStock()
    {
        Stock = 0;
    }

    public void Update(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }
}
