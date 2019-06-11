using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IOrderService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        List<Order> GetAll();

        [OperationContract]
        bool Add(Order order);

        [OperationContract]
        bool Delete(int orderId);

        [OperationContract]
        bool UpdateOrder(int orderId, Order order);

        [OperationContract]
        bool UpdateOrderNumber(int orderId, string orderNumber);

        [OperationContract]
        bool UpdateOrderDate(int orderId, DateTime orderDate);

        [OperationContract]
        bool UpdateDescription(int orderId, string description);

        [OperationContract]
        bool UpdateDriver(int orderId, Driver driver);

        [OperationContract]
        bool UpdateCustomer(int orderId, Customer customer);

        [OperationContract]
        bool UpdateOrderLines(int orderId, IList<OrderLines> orderLines);
    }
}
