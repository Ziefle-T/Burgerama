using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IOrderLinesService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IOrderLinesService
    {
        [OperationContract]
        List<OrderLines> GetAll();

        [OperationContract]
        bool Add(OrderLines orderLines);

        [OperationContract]
        bool Delete(int orderLinesId);

        [OperationContract]
        bool UpdateAmount(int orderLinesId, int amount);

        [OperationContract]
        bool UpdatePosition(int orderLinesId, int position);

        [OperationContract]
        bool UpdateOrder(int orderLinesId, Order order);

        [OperationContract]
        bool UpdateArticle(int orderLinesId, Article article);
    }
}
