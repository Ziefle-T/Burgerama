using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;

namespace Server.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IAreaService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IAreaService
    {
        [OperationContract]
        List<Area> GetAll();

        [OperationContract]
        bool Add(Area area);

        [OperationContract]
        bool Delete(int areaId);

        [OperationContract]
        int UpdateArea(int areaId, Area area);
        
        [OperationContract]
        bool UpdateName(int areaId, string name);

        [OperationContract]
        bool UpdatePlz(int areaId, int plz);

        [OperationContract]
        bool UpdateDrivers(int areaId, List<Driver> drivers);
    }
}
