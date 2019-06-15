using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Exceptions;
using Server.Framework;
using Server.Models;

namespace ServerTest.Framework
{
    [TestClass]
    public class RepositoryCustomerTest
    {
        private string databaseFile = AppContext.BaseDirectory + "\\TestDatabase\\BurgeramaX.db";
        private string databaseSourceFile = AppContext.BaseDirectory + "\\TestDatabase\\Burgerama.db";

        private NHibernateHelper mHibernateHelper;
        private Repository<Customer> mCustomerRepository;

        [TestInitialize]
        public void InitialiseTest()
        {
            //Guarantee an empty database at start
            if (File.Exists(databaseFile))
            {
                File.Delete(databaseFile);
            }

            File.Copy(databaseSourceFile, databaseFile);

            mHibernateHelper = new NHibernateHelper(databaseFile);
            mCustomerRepository = new Repository<Customer>(mHibernateHelper);
        }

        [TestMethod]
        public void EmptyTest()
        {
            List<Customer> emptyArticleList = mCustomerRepository.GetAll();

            Assert.AreEqual(0, emptyArticleList.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest1()
        {
            Customer insertCustomer = new Customer()
            {
                FirstName = "Olaf",
                LastName = "Gerd",
                City = "Horb",
                Phone = "+49151236498",
                Plz = 56348,
                Street = "Florianstraße",
                StreetNumber = "15",
                Type = 1
            };

            mCustomerRepository.Save(insertCustomer);
            List<Customer> savedCustomers = mCustomerRepository.GetAll();

            Assert.AreEqual(1, savedCustomers.Count);
            Customer returnedCustomer = savedCustomers[0];
            Assert.AreEqual(insertCustomer.FirstName, returnedCustomer.FirstName);
            Assert.AreEqual(insertCustomer.LastName, returnedCustomer.LastName);
            Assert.AreEqual(insertCustomer.City, returnedCustomer.City);
            Assert.AreEqual(insertCustomer.Phone, returnedCustomer.Phone);
            Assert.AreEqual(insertCustomer.Plz, returnedCustomer.Plz);
            Assert.AreEqual(insertCustomer.Street, returnedCustomer.Street);
            Assert.AreEqual(insertCustomer.StreetNumber, returnedCustomer.StreetNumber);
        }

        [TestMethod]
        public void SaveAndGetAllTest2()
        {
            Customer insertCustomer1 = new Customer()
            {
                FirstName = "Olaf",
                LastName = "Gerd",
                City = "Horb",
                Phone = "+49151236498",
                Plz = 56348,
                Street = "Florianstraße",
                StreetNumber = "15",
                Type = 1
            };
            Customer insertCustomer2 = new Customer()
            {
                FirstName = "Antonius",
                LastName = "Lukas",
                City = "Stuttgart",
                Phone = "+493451236",
                Plz = 567345,
                Street = "Dingsbumsstraße",
                StreetNumber = "65c",
                Type = 1
            };

            mCustomerRepository.Save(insertCustomer1);
            mCustomerRepository.Save(insertCustomer2);
            List<Customer> savedCustomers = mCustomerRepository.GetAll();

            Assert.AreEqual(2, savedCustomers.Count);
            Customer returnedCustomer1 = savedCustomers[0];
            Assert.AreEqual(insertCustomer1.FirstName, returnedCustomer1.FirstName);
            Assert.AreEqual(insertCustomer1.LastName, returnedCustomer1.LastName);
            Assert.AreEqual(insertCustomer1.City, returnedCustomer1.City);
            Assert.AreEqual(insertCustomer1.Phone, returnedCustomer1.Phone);
            Assert.AreEqual(insertCustomer1.Plz, returnedCustomer1.Plz);
            Assert.AreEqual(insertCustomer1.Street, returnedCustomer1.Street);
            Assert.AreEqual(insertCustomer1.StreetNumber, returnedCustomer1.StreetNumber);
            
            Customer returnedCustomer2 = savedCustomers[1];
            Assert.AreEqual(insertCustomer2.FirstName, returnedCustomer2.FirstName);
            Assert.AreEqual(insertCustomer2.LastName, returnedCustomer2.LastName);
            Assert.AreEqual(insertCustomer2.City, returnedCustomer2.City);
            Assert.AreEqual(insertCustomer2.Phone, returnedCustomer2.Phone);
            Assert.AreEqual(insertCustomer2.Plz, returnedCustomer2.Plz);
            Assert.AreEqual(insertCustomer2.Street, returnedCustomer2.Street);
            Assert.AreEqual(insertCustomer2.StreetNumber, returnedCustomer2.StreetNumber);
        }

        [TestMethod]
        public void BreakUniquePhoneConstraintTest()
        {
            Customer insertCustomer1 = new Customer()
            {
                FirstName = "Olaf",
                LastName = "Gerd",
                City = "Horb",
                Phone = "+49151236498",
                Plz = 56348,
                Street = "Florianstraße",
                StreetNumber = "15",
                Type = 1
            };
            Customer insertCustomer2 = new Customer()
            {
                FirstName = "Antonius",
                LastName = "Lukas",
                City = "Stuttgart",
                Phone = "+49151236498",
                Plz = 567345,
                Street = "Dingsbumsstraße",
                StreetNumber = "65c",
                Type = 1
            };

            mCustomerRepository.Save(insertCustomer1);

            Assert.ThrowsException<GenericADOException>(() => mCustomerRepository.Save(insertCustomer2));
        }

        [TestMethod]
        public void SaveDeleteAndGetAllTest1()
        {
            Customer insertCustomer1 = new Customer()
            {
                FirstName = "Olaf",
                LastName = "Gerd",
                City = "Horb",
                Phone = "+49151236498",
                Plz = 56348,
                Street = "Florianstraße",
                StreetNumber = "15",
                Type = 1
            };
            Customer insertCustomer2 = new Customer()
            {
                FirstName = "Antonius",
                LastName = "Lukas",
                City = "Stuttgart",
                Phone = "+493451236",
                Plz = 567345,
                Street = "Dingsbumsstraße",
                StreetNumber = "65c",
                Type = 1
            };

            mCustomerRepository.Save(insertCustomer1);
            mCustomerRepository.Save(insertCustomer2);

            mCustomerRepository.Delete(insertCustomer1);

            List<Customer> savedCustomers = mCustomerRepository.GetAll();

            Assert.AreEqual(1, savedCustomers.Count);

            Customer returnedCustomer1 = savedCustomers[0];
            Assert.AreEqual(insertCustomer2.FirstName, returnedCustomer1.FirstName);
            Assert.AreEqual(insertCustomer2.LastName, returnedCustomer1.LastName);
            Assert.AreEqual(insertCustomer2.City, returnedCustomer1.City);
            Assert.AreEqual(insertCustomer2.Phone, returnedCustomer1.Phone);
            Assert.AreEqual(insertCustomer2.Plz, returnedCustomer1.Plz);
            Assert.AreEqual(insertCustomer2.Street, returnedCustomer1.Street);
            Assert.AreEqual(insertCustomer2.StreetNumber, returnedCustomer1.StreetNumber);
        }
    }
}
