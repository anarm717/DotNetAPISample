namespace NHibernateSample.Controllers;
using Microsoft.AspNetCore.Mvc;
using NHibernateSample.Repository;
using NHibernateSample.Services;

[Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    //[Authorize(Roles = "Reader")]
    public IActionResult GetAll()
    {
        var allBooks = _bookService.GetAllItems();
        return Ok(allBooks);
    }
}