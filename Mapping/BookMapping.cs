// BookMap.cs
namespace NHibernateSample.Mapping;
using FluentNHibernate.Mapping;
using NHibernateSample.Models;

public class BookMapping : ClassMap<Book>
{
    public BookMapping()
    {
        Id(x => x.Id);
        Map(x => x.Title);
        Map(x => x.Author);
        Map(x => x.Price);
        Table("Books");
    }
}
