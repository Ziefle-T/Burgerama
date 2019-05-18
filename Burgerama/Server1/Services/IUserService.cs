using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;

namespace Server1.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IUserService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<Customer> GetAll();

        [OperationContract]
        bool Add(User user);

        [OperationContract]
        bool Update(User user);

        [OperationContract]
        bool Delete(User user);

        [OperationContract]
        (bool success, bool isAdmin) Login(string userName, string password);
    }
}
