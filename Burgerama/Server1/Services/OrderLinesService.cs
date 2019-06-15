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
    public class OrderLinesService : UpdatableService<OrderLines>, IOrderLinesService
    {
        public OrderLinesService(IRepository<OrderLines> repository) : base(repository) {}

        public override List<OrderLines> GetAll()
        {
            var list = base.GetAll();
            if (list == null)
            {
                return new List<OrderLines>();
            }

            foreach (var orderLine in list)
            {
                orderLine.Order.OrderLines = null;
                foreach (var driverArea in orderLine.Order.Driver.Areas)
                {
                    driverArea.Drivers = null;
                }
            }

            return list;
        }

        public bool UpdateAmount(int orderLinesId, int amount)
        {
            return Update(orderLinesId, x => x.Amount = amount);
        }

        public bool UpdateArticle(int orderLinesId, Article article)
        {
            return Update(orderLinesId, x => x.Article = article);
        }

        public bool UpdateOrder(int orderLinesId, Order order)
        {
            return Update(orderLinesId, x => x.Order = order);
        }

        public bool UpdatePosition(int orderLinesId, int position)
        {
            return Update(orderLinesId, x => x.Position = position);
        }

        public override OrderLines GetElementById(int id)
        {
            return mRepository.GetAllWhere(x => x.Id == id).FirstOrDefault();
        }
    }
}
