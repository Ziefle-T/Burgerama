using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;

namespace Server.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "ICustomerService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetAll();

        [OperationContract]
        bool Add(Customer customer);

        [OperationContract]
        bool Delete(int customerId);

        [OperationContract]
        bool UpdateFirstName(int customerId, string firstName);

        [OperationContract]
        bool UpdateLastName(int customerId, string lastName);

        [OperationContract]
        bool UpdatePhone(int customerId, string phone);

        [OperationContract]
        bool UpdateStreet(int customerId, string street);

        [OperationContract]
        bool UpdateStreetNumber(int customerId, string streetNumber);

        [OperationContract]
        bool UpdatePlz(int customerId, int plz);

        [OperationContract]
        bool UpdateCity(int customerId, string city);
    }
}
