using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    [DataContract]
    public class OrderLines
    {
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int ArticleId { get; set; }
    }
}
