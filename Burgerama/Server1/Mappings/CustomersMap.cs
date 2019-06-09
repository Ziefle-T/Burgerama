using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Server.Models;

namespace Server.Mappings
{
    class CustomersMap : ClassMap<Customer>
    {
        public CustomersMap()
        {
            Table("Customers");

            Id(x => x.Id);

            Map(x => x.LastName).Column("Name").Length(50).Not.Nullable();
            Map(x => x.FirstName).Column("Firstname").Length(50);
            Map(x => x.Phone).Length(50).Not.Nullable();
            Map(x => x.Street).Length(50).Not.Nullable();
            Map(x => x.StreetNumber).Length(5).Not.Nullable();
            Map(x => x.Plz).Column("PostalCode").Not.Nullable();
            Map(x => x.City).Length(50).Not.Nullable();
            Map(x => x.Type).Column("Type").Not.Nullable();
        }
    }
}
