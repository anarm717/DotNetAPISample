using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Business.Interfaces;
public interface IAuthorRepository
{
    void AddAuthor(Author book);
    Author GetAuthorById(int id);
    IList<Author> GetAllAuthors();
    void UpdateAuthor(Author book);
    void DeleteAuthor(int id);
}
