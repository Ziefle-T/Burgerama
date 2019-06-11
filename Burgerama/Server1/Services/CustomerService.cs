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
    public class CustomerService : UpdatableService<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repository) : base(repository) {}

        public override bool Add(Customer customer)
        {
            customer.Type = 1;
            return base.Add(customer);
        }

        public bool UpdateCity(int customerId, string city)
        {
            return Update(customerId, x => x.City = city);
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }
            return UpdateElement(customer.Id, customer);
        }

        public bool UpdateFirstName(int customerId, string firstName)
        {
            return Update(customerId, x => x.FirstName = firstName);
        }

        public bool UpdateLastName(int customerId, string lastName)
        {
            return Update(customerId, x => x.LastName = lastName);
        }

        public bool UpdatePhone(int customerId, string phone)
        {
            return Update(customerId, x => x.Phone = phone);
        }

        public bool UpdatePlz(int customerId, int plz)
        {
            return Update(customerId, x => x.Plz = plz);
        }

        public bool UpdateStreet(int customerId, string street)
        {
            return Update(customerId, x => x.Street = street);
        }

        public bool UpdateStreetNumber(int customerId, string streetNumber)
        {
            return Update(customerId, x => x.StreetNumber = streetNumber);
        }

        public override Customer GetElementById(int id)
        {
            return mRepository.GetAllWhere(x => x.Id == id).FirstOrDefault();
        }
    }
}
