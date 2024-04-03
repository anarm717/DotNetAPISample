using NHibernate;
using NHibernateSample.Application.DTOs;
using NHibernateSample.Application.Interfaces;
using NHibernateSample.Application.Mappers;
using NHibernateSample.Business.Exceptions;
using NHibernateSample.Business.Interfaces;

namespace NHibernateSample.Business.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookMapper _mapper;

    public BookService(IBookRepository bookRepository, IBookMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public IEnumerable<BookDto> GetAllBooks()
    {
        var books = _bookRepository.GetAllBooks();
        return _mapper.MapsToDtos(books);
    }

    public BookDto GetBookById(int id)
    {
        var book = _bookRepository.GetBookById(id);
        return _mapper.MapToDto(book);
    }

    public int CreateBook(BookDto bookDto)
    {
        var bookEntity = _mapper.MapToEntity(bookDto);
        _bookRepository.AddBook(bookEntity);
        return bookEntity.Id;
    }

    public void UpdateBook(int id, BookDto bookDto)
    {
        var existingBook = _bookRepository.GetBookById(id);
        if (existingBook == null)
        {
            throw new NotFoundException("Book not found.");
        }

        existingBook = _mapper.MapToEntity(bookDto);
        _bookRepository.UpdateBook(existingBook);
    }

    public void DeleteBook(int id)
    {
        var existingBook = _bookRepository.GetBookById(id);
        if (existingBook == null)
        {
            throw new NotFoundException("Book not found.");
        }

        _bookRepository.DeleteBook(id);
    }
}
