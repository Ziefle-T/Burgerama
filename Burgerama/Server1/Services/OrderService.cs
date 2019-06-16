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
        private IRepository<OrderLines> mOrderLinesRepository;

        public OrderService(IRepository<Order> repository, IRepository<OrderLines> orderLinesRepository) 
            : base(repository)
        {
            mOrderLinesRepository = orderLinesRepository;
        }

        public override List<Order> GetAll()
        {
            var list = base.GetAll();

            if (list == null)
            {
                return new List<Order>();
            }

            foreach (var order in list)
            {
                foreach (var orderLine in order.OrderLines)
                {
                    orderLine.Order = null;
                }

                order.Driver.Areas = null;
            }

            return list;
        }

        public override bool Add(Order order)
        {
            try
            {
                var orderLines = order.OrderLines;

                foreach (var orderLine in orderLines)
                {
                    orderLine.Order = order;
                }

                order.OrderLines = new List<OrderLines>();
                if (base.Add(order))
                {
                    foreach (var orderLine in orderLines)
                    {
                        mOrderLinesRepository.Save(orderLine);
                    }

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateOrder(int orderId, Order order)
        {
            try
            {
                var orderLines = order.OrderLines.ToList();

                foreach (var orderLine in mOrderLinesRepository.GetAllWhere(x => x.Order.Id == orderId))
                {
                    if (!orderLines.Contains(orderLine))
                    {
                        mOrderLinesRepository.Delete(orderLine);
                    }
                    //else
                    //{

                    //    orderLines.Remove(orderLine);
                    //}
                }
                
                foreach (var orderLine in orderLines)
                {
                    orderLine.Order = order;
                }

                order.OrderLines = new List<OrderLines>();
                if (UpdateElement(orderId, order))
                {
                    foreach (var orderLine in orderLines)
                    {
                        mOrderLinesRepository.Save(orderLine);
                    }

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public override bool Delete(int id)
        {
            try
            {
                var element = GetElementById(id);
                if (element == null)
                {
                    return false;
                }

                foreach (var orderLine in element.OrderLines)
                {
                    mOrderLinesRepository.Delete(orderLine);
                }
                mRepository.Delete(element);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateOrderLines(int orderId, IList<OrderLines> orderLines)
        {
            return Update(orderId, x => x.OrderLines = orderLines);
        }

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

        public override Order GetElementById(int id)
        {
            return mRepository.GetAllWhere(x => x.Id == id).FirstOrDefault();
        }
    }
}
