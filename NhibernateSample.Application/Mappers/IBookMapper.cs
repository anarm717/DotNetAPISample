
using NHibernateSample.Application.DTOs;
using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Application.Mappers
{
    public interface IBookMapper
    {
        BookDto MapToDto(Book book);
        Book MapToEntity(BookDto bookDto);

        IEnumerable<BookDto> MapsToDtos(IEnumerable<Book> books);
    }
}
