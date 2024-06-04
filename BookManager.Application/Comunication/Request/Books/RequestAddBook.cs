namespace BookManager.Application.Comunication.Request.Books;

public class RequestAddBook
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int Stock { get; set; }
}