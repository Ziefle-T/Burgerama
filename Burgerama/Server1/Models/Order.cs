using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string OrderNumber { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Driver Driver { get; set; }

        [DataMember]
        public Customer Customer { get; set; }

        [DataMember]
        public IList<OrderLines> OrderLines { get; set; }

        [DataMember]
        public int Version { get; set; }
    }
}
