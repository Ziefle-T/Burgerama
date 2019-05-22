﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    [DataContract]
    public class Area
    {
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Plz { get; set; }

        public IList<Driver> Drivers { get; set; }
    }
}
