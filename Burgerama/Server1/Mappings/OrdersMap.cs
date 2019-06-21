using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Server.Models;

namespace Server.Mappings
{
    class OrdersMap : ClassMap<Order>
    {
        public OrdersMap()
        {
            Table("Orders");

            Id(x => x.Id);

            Map(x => x.OrderNumber).Length(50).Not.Nullable();
            Map(x => x.OrderDate).Not.Nullable();
            Map(x => x.Description).Length(100).Nullable();
            References(x => x.Driver)
                .Column("EmployeeId")
                .Not.Nullable();
            References(x => x.Customer)
                .Column("CustomerId")
                .Not.Nullable()
                .Cascade.SaveUpdate();
            HasMany(x => x.OrderLines)
                .KeyColumn("OrderId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            Version(x => x.Version);
        }
    }
}
