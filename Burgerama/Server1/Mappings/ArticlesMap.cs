using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Server.Models;

namespace Server.Mappings
{
    class ArticlesMap : ClassMap<Article>
    {
        public ArticlesMap()
        {
            Table("Articles");

            Id(x => x.Id);

            Map(x => x.ArticleNumber).Length(50).Unique().Not.Nullable();
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.Description).Length(100);
            Map(x => x.Price).Scale(16).Precision(2).Not.Nullable();
        }
    }
}
