namespace NHibernateSample.Application.Interfaces;
using NHibernateSample.Application.DTOs;

public interface IBookService
{
    IEnumerable<BookDto> GetAllBooks();
    BookDto GetBookById(int id);
    int CreateBook(BookDto bookDto);
    void UpdateBook(int id, BookDto bookDto);
    void DeleteBook(int id);
}
