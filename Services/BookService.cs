namespace NHibernateSample.Services;
using NHibernateSample.Models;
public interface IBookService
{
    IList<Book> GetAllItems();
}