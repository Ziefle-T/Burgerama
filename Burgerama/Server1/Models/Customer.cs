﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string StreetNumber { get; set; }
        [DataMember]
        public int Plz { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public int Version { get; set; }

        public int Type { get; set; }
    }
}
