
using NHibernateSample.Application.DTOs;
using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Application.Mappers
{
    public interface IAuthorMapper
    {
        AuthorDto MapToDto(Author author);
        Author MapToEntity(AuthorDto authorDto);

        IEnumerable<AuthorDto> MapsToDtos(IEnumerable<Author> authors);
    }
}
