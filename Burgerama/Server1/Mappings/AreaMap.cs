using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Server.Models;

namespace Server.Mappings
{
    public class AreaMap : ClassMap<Area>
    {
        public AreaMap()
        {
            Table("Areas");

            Id(x => x.Id);

            Map(x => x.Name).Column("Description").Length(50).Not.Nullable();
            Map(x => x.Plz).Column("PostCode").Not.Nullable();

            HasManyToMany(x => x.Drivers)
                .Table("EmployeeToAreaRelations")
                .ParentKeyColumn("AreaId")
                .ChildKeyColumn("EmployeeId")
                .Inverse();

        }
    }
}