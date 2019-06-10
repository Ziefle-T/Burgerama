using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;

namespace Server.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IUserService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<User> GetAll();

        [OperationContract]
        bool Add(User user);

        [OperationContract]
        bool UpdateUsername(int userId, string username);

        [OperationContract]
        bool UpdateFirstname(int userId, string firstname);

        [OperationContract]
        bool UpdateLastname(int userId, string lastname);

        [OperationContract]
        bool UpdatePassword(int userId, string oldPassword, string password);

        [OperationContract]
        bool UpdateAdmin(int userId, bool isAdmin);

        [OperationContract]
        bool Delete(int userId);

        [OperationContract]
        (bool success, User user) Login(string userName, string password);
    }
}
