using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Framework;
using Server.Models;

namespace Server.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class DriverService : UpdatableService<Driver>, IDriverService
    {
        public DriverService(IRepository<Driver> repository) : base(repository) {}

        public bool UpdateFirstName(int driverId, string firstName)
        {
            return Update(driverId, x => x.FirstName = firstName);
        }

        public bool UpdateLastName(int driverId, string lastName)
        {
            return Update(driverId, x => x.LastName = lastName);
        }

        public bool UpdateEmployeeNumber(int driverId, int employeeNumber)
        {
            return Update(driverId, x => x.EmployeeNumber = employeeNumber);
        }

        public bool UpdateAreas(int driverId, List<Area> areas)
        {
            return Update(driverId, x => x.Areas = areas);
        }

        public override bool EqualsId(Driver obj, int id)
        {
            return obj.Id == id;
        }
    }
}
