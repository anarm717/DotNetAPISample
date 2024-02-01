// Book.cs
namespace NHibernateSample.Models;
public class Book
{
    public virtual int Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Author { get; set; }
    public virtual decimal Price { get; set; }
}
