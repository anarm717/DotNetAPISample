using NHibernate;
using NHibernateSample.Application.DTOs;
using NHibernateSample.Application.Interfaces;
using NHibernateSample.Application.Mappers;
using NHibernateSample.Business.Exceptions;
using NHibernateSample.Business.Interfaces;

namespace NHibernateSample.Business.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _bookRepository;
    private readonly IAuthorMapper _mapper;

    public AuthorService(IAuthorRepository bookRepository, IAuthorMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public IEnumerable<AuthorDto> GetAllAuthors()
    {
        var books = _bookRepository.GetAllAuthors();
        return _mapper.MapsToDtos(books);
    }

    public AuthorDto GetAuthorById(int id)
    {
        var book = _bookRepository.GetAuthorById(id);
        return _mapper.MapToDto(book);
    }

    public int CreateAuthor(AuthorDto bookDto)
    {
        var bookEntity = _mapper.MapToEntity(bookDto);
        _bookRepository.AddAuthor(bookEntity);
        return bookEntity.Id;
    }

    public void UpdateAuthor(int id, AuthorDto bookDto)
    {
        var existingAuthor = _bookRepository.GetAuthorById(id);
        if (existingAuthor == null)
        {
            throw new NotFoundException("Author not found.");
        }

        existingAuthor = _mapper.MapToEntity(bookDto);
        _bookRepository.UpdateAuthor(existingAuthor);
    }

    public void DeleteAuthor(int id)
    {
        var existingAuthor = _bookRepository.GetAuthorById(id);
        if (existingAuthor == null)
        {
            throw new NotFoundException("Author not found.");
        }

        _bookRepository.DeleteAuthor(id);
    }
}
