using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;

namespace Server1.Services
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
        bool Update(Driver driver);

        [OperationContract]
        bool Delete(Driver driver);
    }
}
