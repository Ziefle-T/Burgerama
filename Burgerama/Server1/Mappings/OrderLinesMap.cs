using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Server.Models;

namespace Server1.Mappings
{
    class OrderLinesMap : ClassMap<OrderLines>
    {
        public OrderLinesMap()
        {
            Table("OrderLines");

            Id(x => x.Id);

            Map(x => x.Amount).Not.Nullable();
            Map(x => x.Position).Not.Nullable();

            References(x => x.Order).Column("OrderId").Not.Nullable();
            References(x => x.Article).Column("ArticleId").Not.Nullable();
        }
    }
}
