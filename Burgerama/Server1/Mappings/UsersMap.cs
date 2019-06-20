using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Server.Models;

namespace Server.Mappings
{
    class UsersMap : ClassMap<User>
    {
        public UsersMap()
        {
            Table("Users");

            Id(x => x.Id);

            Map(x => x.Username).Length(20).Unique().Not.Nullable();
            Map(x => x.Firstname).Length(50).Nullable();
            Map(x => x.Lastname).Length(50).Not.Nullable();
            Map(x => x.Password).Length(60).Not.Nullable();
            Map(x => x.IsAdmin).Not.Nullable();

            Version(x => x.Version);
        }
    }
}
