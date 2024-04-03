namespace NHibernateSample.Application.DTOs;
public class AuthorDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public int BornYear { get; set; }
    // Add other properties as needed
}