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
            return base.Add(area);
        }

        public override List<Area> GetAll()
        {
            var list = base.GetAll();

            if (list == null)
            {
                return new List<Area>();
            }

            foreach (var area in list)
            {
                area.Drivers = null;
            }

            return list;
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

        public int UpdateArea(int areaId, Area area)
        {
            return base.UpdateElement(areaId, area);
        }
    }
}
