using FluentNHibernate.Mapping;
using NHibernateSample.Domain.Entities;
namespace NHibernateSample.Domain.Mappers;
public class AuthorMapper : ClassMap<Author>
{
    public AuthorMapper()
    {
        Id(x => x.Id);
        Map(x => x.Name);
        Map(x => x.Surname);
        Map(x => x.BornYear);
        Table("Authors");
    }
}