using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Framework;
using Server.Models;

namespace Server1.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "DriverService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    public class DriverService : IDriverService
    {
        private IRepository<Driver> mDriverRepository;

        public DriverService(IRepository<Driver> driverRepository)
        {
            mDriverRepository = driverRepository;
        }

        public bool Add(Driver driver)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Driver driver)
        {
            throw new NotImplementedException();
        }

        public List<Driver> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
