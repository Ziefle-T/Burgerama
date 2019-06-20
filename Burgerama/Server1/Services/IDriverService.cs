using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;

namespace Server.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IDriverService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IDriverService
    {
        [OperationContract]
        List<Driver> GetAll();

        [OperationContract]
        bool Add(Driver driver);

        [OperationContract]
        int UpdateDriver(int driverId, Driver driver);
        
        [OperationContract]
        bool UpdateFirstName(int driverId, string firstName);

        [OperationContract]
        bool UpdateLastName(int driverId, string lastName);

        [OperationContract]
        bool UpdateEmployeeNumber(int driverId, int employeeNumber);

        [OperationContract]
        bool UpdateAreas(int driverId, List<Area> areas);

        [OperationContract]
        bool Delete(int driverId);
    }
}
