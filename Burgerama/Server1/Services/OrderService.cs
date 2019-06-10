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
    public class OrderService : UpdatableService<Order>, IOrderService
    {
        public OrderService(IRepository<Order> repository) : base(repository) {}
        
        public bool UpdateCustomer(int orderId, Customer customer)
        {
            return Update(orderId, x => x.Customer = customer);
        }

        public bool UpdateDescription(int orderId, string description)
        {
            return Update(orderId, x => x.Description = description);
        }

        public bool UpdateDriver(int orderId, Driver driver)
        {
            return Update(orderId, x => x.Driver = driver);
        }

        public bool UpdateOrderDate(int orderId, DateTime orderDate)
        {
            return Update(orderId, x => x.OrderDate = orderDate);
        }

        public bool UpdateOrderNumber(int orderId, string orderNumber)
        {
            return Update(orderId, x => x.OrderNumber = orderNumber);
        }

        public override bool EqualsId(Order obj, int id)
        {
            return obj.Id == id;
        }
    }
}
