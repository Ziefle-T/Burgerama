using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    [DataContract]
    public class Article
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ArticleNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int Version { get; set; }
    }
}
