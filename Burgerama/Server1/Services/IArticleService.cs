using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;

namespace Server.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IArticleService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IArticleService
    {
        [OperationContract]
        List<Article> GetAll();

        [OperationContract]
        bool Add(Article article);

        [OperationContract]
        bool Delete(int articleId);

        [OperationContract]
        bool UpdateArticleNumber(int articleId, string articleNumber);

        [OperationContract]
        bool UpdateName(int articleId, string name);

        [OperationContract]
        bool UpdateDescription(int articleId, string description);

        [OperationContract]
        bool UpdatePrice(int articleId, decimal price);
    }
}
