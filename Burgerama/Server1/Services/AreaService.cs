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
    public class AreaService : UpdatableService<Area>, IAreaService
    {
        public AreaService(IRepository<Area> repository) : base(repository) { }

        public override bool Add(Area area)
        {
            Area existingArea = mRepository.GetAllWhere(x => x.Id == area.Id).FirstOrDefault();
            if (existingArea != null)
            {
                return false;
            }

            return base.Add(area);
        }

        public bool UpdateDrivers(int areaId, List<Driver> drivers)
        {
            return Update(areaId, x => x.Drivers = drivers);
        }

        public bool UpdateName(int areaId, string name)
        {
            return Update(areaId, x => x.Name = name);
        }

        public bool UpdatePlz(int areaId, int plz)
        {
            return Update(areaId, x => x.Plz = plz);
        }

        public override Area GetElementById(int id)
        {
            return mRepository.GetAllWhere(x => x.Id == id).FirstOrDefault();
        }

        public bool UpdateArea(int areaId, Area area)
        {
            return base.UpdateElement(areaId, area);
        }
    }
}
