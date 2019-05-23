using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Server1.Models;

namespace Server1.Mappings
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
            References(x => x.Driver).Column("EmployeeId")
                .Not.Nullable()
                .Cascade.SaveUpdate();
            References(x => x.Customer).Column("CustomerId")
                .Not.Nullable()
                .Cascade.SaveUpdate();
        }
    }
}
