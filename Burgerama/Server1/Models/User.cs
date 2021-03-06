﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }

        [DataMember]
        public int Version { get; set; }

        public bool ValidatePw(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, this.Password);
        }

        public void SetNewPassword(string password)
        {
            this.Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
