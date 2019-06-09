using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Server.Models;

namespace Server.Mappings
{
    class DriversMap : ClassMap<Driver>
    {
        public DriversMap()
        {
            Table("Employees");

            Id(x => x.Id);

            Map(x => x.FirstName).Length(50).Not.Nullable();
            Map(x => x.LastName).Length(50).Not.Nullable();
            Map(x => x.EmployeeNumber).Unique().Not.Nullable();

            HasManyToMany(x => x.Areas)
                .Table("EmployeeToAreaRelations")
                .ParentKeyColumn("EmployeeId")
                .ChildKeyColumn("AreaId")
                .Cascade.SaveUpdate();
        }
    }
}
