using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Server
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string StreetNumber { get; set; }
        public int Plz { get; set; }
        public string City { get; set; }
    }
}
