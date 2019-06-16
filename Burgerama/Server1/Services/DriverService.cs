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
        private IRepository<Area> mAreaRepository;

        public DriverService(IRepository<Driver> repository, IRepository<Area> areaRepository) : base(repository)
        {
            mAreaRepository = areaRepository;
        }

        public override List<Driver> GetAll()
        {
            var list = base.GetAll();

            foreach (var driver in list)
            {
                foreach (var driverArea in driver.Areas)
                {
                    driverArea.Drivers = null;
                }
            }

            return list;
        }

        public override bool Delete(int driverId)
        {
            try
            {
                Driver driver = GetElementById(driverId);

                if (driver == null)
                {
                    return false;
                }

                foreach (var driverArea in driver.Areas)
                {
                    driverArea.Drivers.Remove(driver);
                    mAreaRepository.Save(driverArea);
                }

                mRepository.Delete(driver);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

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

        public override Driver GetElementById(int id)
        {
            return mRepository.GetAllWhere(x => x.Id == id).FirstOrDefault();
        }

        public bool UpdateDriver(int driverId, Driver driver)
        {
            return UpdateElement(driverId, driver);
        }
    }
}
