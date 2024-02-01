using NHibernateSample.Models;
namespace NHibernateSample.Repository;
public class BookRepository
{
    public void AddBook(Book book)
    {
        using (var session = NHibernateHelper.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            session.Save(book);
            transaction.Commit();
        }
    }

    public IList<Book> GetAllBooks()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            return session.Query<Book>().ToList();
        }
    }
}
