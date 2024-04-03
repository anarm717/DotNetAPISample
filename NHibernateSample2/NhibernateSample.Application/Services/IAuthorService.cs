namespace NHibernateSample.Application.Interfaces;
using NHibernateSample.Application.DTOs;

public interface IAuthorService
{
    IEnumerable<AuthorDto> GetAllAuthors();
    AuthorDto GetAuthorById(int id);
    int CreateAuthor(AuthorDto authorDto);
    void UpdateAuthor(int id, AuthorDto authorDto);
    void DeleteAuthor(int id);
}
