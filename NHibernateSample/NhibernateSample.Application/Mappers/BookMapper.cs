using NHibernateSample.Application.DTOs;
using NHibernateSample.Domain.Entities;
using AutoMapper;
namespace NHibernateSample.Application.Mappers;

public class BookMapper : IBookMapper
{
    private readonly IMapper _mapper;

    public BookMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public BookDto MapToDto(Book book)
    {
        return _mapper.Map<BookDto>(book);
    }

    public Book MapToEntity(BookDto bookDto)
    {
        return _mapper.Map<Book>(bookDto);
    }

    public IEnumerable<BookDto> MapsToDtos(IEnumerable<Book> books)
    {
        return _mapper.Map<IEnumerable<BookDto>>(books);
    }
}
