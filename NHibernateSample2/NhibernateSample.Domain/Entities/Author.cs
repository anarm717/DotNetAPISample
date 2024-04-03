// Author.cs
namespace NHibernateSample.Domain.Entities;
public class Author
{
    public virtual int Id { get; set; }
    public virtual required string Name { get; set; }
    public virtual required string Surname { get; set; }
    public virtual int BornYear { get; set; }
}
