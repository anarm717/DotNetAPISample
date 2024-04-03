using NHibernateSample.Application.DTOs;
using NHibernateSample.Domain.Entities;
using AutoMapper;
namespace NHibernateSample.Application.Mappers;

public class AuthorMapper : IAuthorMapper
{
    private readonly IMapper _mapper;

    public AuthorMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public AuthorDto MapToDto(Author author)
    {
        return _mapper.Map<AuthorDto>(author);
    }

    public Author MapToEntity(AuthorDto authorDto)
    {
        return _mapper.Map<Author>(authorDto);
    }

    public IEnumerable<AuthorDto> MapsToDtos(IEnumerable<Author> authors)
    {
        return _mapper.Map<IEnumerable<AuthorDto>>(authors);
    }
}
