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
    public class ArticleService : UpdatableService<Article>, IArticleService
    {
        public ArticleService(IRepository<Article> repository) : base(repository) {}

        public bool UpdateArticleNumber(int articleId, string articleNumber)
        {
            return Update(articleId, x => x.ArticleNumber = articleNumber);
        }

        public bool UpdateDescription(int articleId, string description)
        {
            return Update(articleId, x => x.Description = description);
        }

        public bool UpdateName(int articleId, string name)
        {
            return Update(articleId, x => x.Name = name);
        }

        public bool UpdatePrice(int articleId, decimal price)
        {
            return Update(articleId, x => x.Price = price);
        }

        public override Article GetElementById(int id)
        {
            return mRepository.GetAllWhere(x => x.Id == id).FirstOrDefault();
        }

        public bool UpdateArticle(int articleId, Article article)
        {
            return UpdateElement(articleId, article);
        }
    }
}
