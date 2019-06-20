using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Server.Framework;

namespace Server.Models
{
    [DataContract]
    public class Area
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Plz { get; set; }
        [DataMember]
        public IList<Driver> Drivers { get; set; }

        [DataMember]
        public int Version { get; set; }

        public void Delete(IRepository<Driver> driverRepository, IRepository<Area> areaRepository)
        {
            foreach (var driver in Drivers)
            {
                driver.Areas.Remove(this);
                driverRepository.Save(driver);
            }
            areaRepository.Delete(this);
        }
    }
}
