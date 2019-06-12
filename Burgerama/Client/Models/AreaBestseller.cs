using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Server.Models;

namespace Client.Models
{
    class AreaBestseller
    {
        public int Rank { get; set; }
        public Area Area { get; set; }
        public decimal Revenue { get; set; }
    }
}
