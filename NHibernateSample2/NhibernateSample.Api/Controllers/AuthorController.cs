using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHibernateSample.Api.Models;
using NHibernateSample.Application.DTOs;
using NHibernateSample.Application.Interfaces;
using NHibernateSample.Business.Exceptions;

namespace NHibernateSample.Api.Controllers;
[ApiController]
[Route("api/authors")]

public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public IActionResult GetAllAuthors()
    {
        var authors = _authorService.GetAllAuthors();
        return Ok(new ApiResponse<IEnumerable<AuthorDto>>(authors));
    }

    [HttpGet("{id}"),Authorize]
    public IActionResult GetAuthorById(int id)
    {
        try
        {
            var author = _authorService.GetAuthorById(id);
            return Ok(new ApiResponse<AuthorDto>(author));
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ApiResponse<object>(ex.Message, ApiResponseCode.NotFound));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<object>(ex.Message, ApiResponseCode.ServerError));
        }
    }

    [HttpPost]
    public IActionResult CreateAuthor([FromBody] AuthorDto authorDto)
    {
        try
        {
            var newAuthorId = _authorService.CreateAuthor(authorDto);
            return CreatedAtAction(nameof(GetAuthorById), new { id = newAuthorId }, null);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<object>(ex.Message, ApiResponseCode.ServerError));
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, [FromBody] AuthorDto authorDto)
    {
        try
        {
            _authorService.UpdateAuthor(id, authorDto);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ApiResponse<object>(ex.Message, ApiResponseCode.NotFound));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<object>(ex.Message, ApiResponseCode.ServerError));
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        try
        {
            _authorService.DeleteAuthor(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ApiResponse<object>(ex.Message, ApiResponseCode.NotFound));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<object>(ex.Message, ApiResponseCode.ServerError));
        }
    }
}
