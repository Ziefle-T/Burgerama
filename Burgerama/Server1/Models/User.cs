using System;
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

        public bool ValidatePw(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, this.Password);
        }

        public void SetNewPassword(string Password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(Password);
        }

    }
}
