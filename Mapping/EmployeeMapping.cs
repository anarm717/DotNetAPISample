using FluentNHibernate.Mapping;
using NHibernateSample.Models;

namespace NHibernate_Tutorial.Mappings
{
    public class EmployeeMapping : ClassMap<Employee>
    {
        public EmployeeMapping()
        {
            Id(x => x.Id);
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Table("Employee");
        }
    }
}
