// Book.cs
namespace NHibernateSample.Domain.Entities;
public class Book
{
    public virtual int Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Author { get; set; }
    public virtual int Year { get; set; }
}
