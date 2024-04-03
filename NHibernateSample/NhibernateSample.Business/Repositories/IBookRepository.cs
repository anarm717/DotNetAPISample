using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Business.Interfaces;
public interface IBookRepository
{
    void AddBook(Book book);
    Book GetBookById(int id);
    IList<Book> GetAllBooks();
    void UpdateBook(Book book);
    void DeleteBook(int id);
}
