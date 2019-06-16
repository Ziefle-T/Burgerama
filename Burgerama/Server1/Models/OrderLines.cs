using Server.Models;
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
        public int Id { get; set; }

        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public int Position { get; set; }

        [DataMember]
        public Order Order { get; set; }
        [DataMember]
        public Article Article { get; set; }

        public override bool Equals(object obj)
        {
            OrderLines orderLine = obj as OrderLines;
            if (orderLine != null)
            {
                return orderLine.Id == Id;
            }

            return false;
        }
    }
}
