using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Server.Models;

namespace Client.Models
{
    class Bestseller
    {
        public int Rank { get; set; }
        public Article Article { get; set; }
        public int Amount { get; set; }

        public decimal Revenue
        {
            get { return Amount * Article.Price; }
        }
    }
}
