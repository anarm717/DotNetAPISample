using NHibernateSample.Business.Interfaces;
using NHibernateSample.Data;
using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Domain.Repositories;
public class AuthorRepository : IAuthorRepository
    {
        public void AddAuthor(Author book)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(book);
                transaction.Commit();
            }
        }

        public Author GetAuthorById(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Author>(id);
            }
        }

        public IList<Author> GetAllAuthors()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Author>().ToList();
            }
        }

        public void UpdateAuthor(Author book)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(book);
                transaction.Commit();
            }
        }

        public void DeleteAuthor(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var bookToDelete = session.Get<Author>(id);
                if (bookToDelete != null)
                {
                    session.Delete(bookToDelete);
                    transaction.Commit();
                }
            }
        }
    }