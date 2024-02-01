namespace NHibernateSample.Services.Implementations;

using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernateSample.Models;
using NHibernateSample.Repository;
using NHibernateSample.Services;

public class BookServiceImpl : IBookService
{
    public IList<Book> GetAllItems()
    {
        var bookRepository = new BookRepository();
        var allBooks = bookRepository.GetAllBooks();
        return allBooks;
    }
}