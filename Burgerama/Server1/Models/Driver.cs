﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    [DataContract]
    public class Driver
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int EmployeeNumber { get; set; }
        [DataMember]
        public IList<Area> Areas { get; set; }
        [DataMember]
        public int Version { get; set; }
    }
}
