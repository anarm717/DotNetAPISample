using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHibernateSample.Api.Models;
using NHibernateSample.Application.DTOs;
using NHibernateSample.Application.Interfaces;
using NHibernateSample.Business.Exceptions;

namespace NHibernateSample.Api.Controllers;
[ApiController]
[Route("api/books")]

public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet,Authorize]
    public IActionResult GetAllBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(new ApiResponse<IEnumerable<BookDto>>(books));
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        try
        {
            var book = _bookService.GetBookById(id);
            return Ok(new ApiResponse<BookDto>(book));
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
    public IActionResult CreateBook([FromBody] BookDto bookDto)
    {
        try
        {
            var newBookId = _bookService.CreateBook(bookDto);
            return CreatedAtAction(nameof(GetBookById), new { id = newBookId }, null);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<object>(ex.Message, ApiResponseCode.ServerError));
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] BookDto bookDto)
    {
        try
        {
            _bookService.UpdateBook(id, bookDto);
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
    public IActionResult DeleteBook(int id)
    {
        try
        {
            _bookService.DeleteBook(id);
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
