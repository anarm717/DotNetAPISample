using NHibernateSample.Business.Interfaces;
using NHibernateSample.Data;
using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Domain.Repositories;
public class BookRepository : IBookRepository
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

        public Book GetBookById(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Book>(id);
            }
        }

        public IList<Book> GetAllBooks()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Book>().ToList();
            }
        }

        public void UpdateBook(Book book)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(book);
                transaction.Commit();
            }
        }

        public void DeleteBook(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var bookToDelete = session.Get<Book>(id);
                if (bookToDelete != null)
                {
                    session.Delete(bookToDelete);
                    transaction.Commit();
                }
            }
        }
    }