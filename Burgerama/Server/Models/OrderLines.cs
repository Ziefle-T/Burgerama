using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class OrderLines
    {
        public int Amount { get; set; }
        public int Position { get; set; }
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
    }
}
