using FluentNHibernate.Mapping;
using NHibernateSample.Domain.Entities;
namespace NHibernateSample.Domain.Mappers;
public class BookMapper : ClassMap<Book>
{
    public BookMapper()
    {
        Id(x => x.Id);
        Map(x => x.Title);
        Map(x => x.Author);
        Map(x => x.Year);
        Table("Books");
    }
}