using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Framework;
using Server.Models;

namespace ServerTest.Framework
{
    [TestClass]
    public class RepositoryOrderTest
    {
        private string databaseFile = AppContext.BaseDirectory + "\\TestDatabase\\BurgeramaX.db";
        private string databaseSourceFile = AppContext.BaseDirectory + "\\TestDatabase\\Burgerama.db";

        private NHibernateHelper mHibernateHelper;
        private Repository<Order> mOrderRepository;

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
            mOrderRepository = new Repository<Order>(mHibernateHelper);
        }

        [TestMethod]
        public void EmptyTest()
        {
            List<Order> emptyOrderList = mOrderRepository.GetAll();

            Assert.AreEqual(0, emptyOrderList.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest1()
        {
            Driver driver = new Driver()
            {
                FirstName = "Günther",
                LastName = "Horst",
                EmployeeNumber = 213,
                Areas = new List<Area>()
            };
            Area area = new Area()
            {
                Name = "Burgertown",
                Plz = 6543,
                Drivers = new List<Driver>()
                {
                    driver
                }
            };
            driver.Areas.Add(area);

            OrderLines orderLines = new OrderLines()
            {
                Amount = 1,
                Article = new Article()
                {
                    ArticleNumber = "132",
                    Description = "bla",
                    Name = "name",
                    Price = 5.8M
                }
            };

            Order order = new Order()
            {
                OrderNumber = "23a",
                Description = "extra viel käse",
                OrderDate = DateTime.Parse("1999-05-01 05:08:12"),
                Customer = new Customer()
                {
                    FirstName = "Olaf",
                    LastName = "Burgereater",
                    City = "Burgertown",
                    Phone = "+4963254",
                    Plz = 59872,
                    Street = "Burgerstreet",
                    StreetNumber = "12a",
                    Type = 1
                },
                Driver = driver,
                OrderLines = new List<OrderLines>()
                {
                    orderLines
                }
            };
            orderLines.Order = order;
            
            mOrderRepository.Save(order);

            List<Order> orderList = mOrderRepository.GetAll();
            Assert.AreEqual(1, orderList.Count);

            Assert.AreEqual("23a", orderList[0].OrderNumber);
            Assert.AreEqual("extra viel käse", orderList[0].Description);
            Assert.AreEqual(DateTime.Parse("1999-05-01 05:08:12"), orderList[0].OrderDate);

            Customer returnedCustomer = orderList[0].Customer;
            Assert.AreEqual("Olaf", returnedCustomer.FirstName);
            Assert.AreEqual("Burgereater", returnedCustomer.LastName);
            Assert.AreEqual("Burgertown", returnedCustomer.City);
            Assert.AreEqual("+4963254", returnedCustomer.Phone);
            Assert.AreEqual(59872, returnedCustomer.Plz);
            Assert.AreEqual("Burgerstreet", returnedCustomer.Street);
            Assert.AreEqual("12a", returnedCustomer.StreetNumber);
            Assert.AreEqual(1, returnedCustomer.Type);

            Driver returnedDriver = orderList[0].Driver;
            Assert.AreEqual("Günther", driver.FirstName);
            Assert.AreEqual("Horst", driver.LastName);
            Assert.AreEqual(213, driver.EmployeeNumber);
            Assert.AreEqual(1, driver.Areas.Count);

            Area driverArea = returnedDriver.Areas[0];
            Assert.AreEqual("Burgertown", driverArea.Name);
            Assert.AreEqual(6543, driverArea.Plz);
            Assert.AreEqual(1, driverArea.Drivers.Count);

            IList<OrderLines> returnedOrderLines = orderList[0].OrderLines;
            Assert.AreEqual(1, returnedOrderLines.Count);
            Assert.AreEqual(1, returnedOrderLines[0].Amount);
            Assert.AreEqual("132", returnedOrderLines[0].Article.ArticleNumber);
            Assert.AreEqual("bla", returnedOrderLines[0].Article.Description);
            Assert.AreEqual("name", returnedOrderLines[0].Article.Name);
            Assert.AreEqual(5.8M, returnedOrderLines[0].Article.Price);
        }

        [TestMethod]
        public void SaveAndGetAllTest2()
        {
            Repository<Driver> driverRepository = new Repository<Driver>(mHibernateHelper);
            Repository<Area> areaRepository = new Repository<Area>(mHibernateHelper);
            Repository<Customer> customerRepository = new Repository<Customer>(mHibernateHelper);

            Driver driver = new Driver()
            {
                FirstName = "Günther",
                LastName = "Horst",
                EmployeeNumber = 213,
                Areas = new List<Area>()
            };
            Area area = new Area()
            {
                Name = "Burgertown",
                Plz = 6543,
                Drivers = new List<Driver>()
                {
                    driver
                }
            };
            driver.Areas.Add(area);

            Customer customer = new Customer()
            {
                FirstName = "Olaf",
                LastName = "Burgereater",
                City = "Burgertown",
                Phone = "+4963254",
                Plz = 59872,
                Street = "Burgerstreet",
                StreetNumber = "12a",
                Type = 1
            };

            Order order = new Order()
            {
                OrderNumber = "23a",
                Description = "extra viel käse",
                OrderDate = DateTime.Parse("1999-05-01 05:08:12"),
                Customer = customer,
                Driver = driver
            };

            mOrderRepository.Save(order);

            List<Driver> savedDrivers = driverRepository.GetAll();
            List<Area> savedAreas = areaRepository.GetAll();
            List<Customer> savedCustomers = customerRepository.GetAll();
            List<Order> savedOrders = mOrderRepository.GetAll();

            Assert.AreEqual(1, savedDrivers.Count);
            Assert.AreEqual("Günther", savedDrivers[0].FirstName);
            Assert.AreEqual("Horst", savedDrivers[0].LastName);
            Assert.AreEqual(213, savedDrivers[0].EmployeeNumber);
            Assert.AreEqual(1, savedDrivers[0].Areas.Count);

            Assert.AreEqual(1, savedAreas.Count);
            Assert.AreEqual("Burgertown", savedAreas[0].Name);
            Assert.AreEqual(6543, savedAreas[0].Plz);
            Assert.AreEqual(1, savedAreas[0].Drivers.Count);

            Assert.AreEqual(1, savedCustomers.Count);
            Assert.AreEqual("Olaf", savedCustomers[0].FirstName);
            Assert.AreEqual("Burgereater", savedCustomers[0].LastName);
            Assert.AreEqual("Burgertown", savedCustomers[0].City);
            Assert.AreEqual("+4963254", savedCustomers[0].Phone);
            Assert.AreEqual(59872, savedCustomers[0].Plz);
            Assert.AreEqual("Burgerstreet", savedCustomers[0].Street);
            Assert.AreEqual("12a", savedCustomers[0].StreetNumber);
            Assert.AreEqual(1, savedCustomers[0].Type);

            Assert.AreEqual(1, savedOrders.Count);
            Assert.AreEqual("23a", savedOrders[0].OrderNumber);
            Assert.AreEqual("extra viel käse", savedOrders[0].Description);
            Assert.AreEqual(DateTime.Parse("1999-05-01 05:08:12"), savedOrders[0].OrderDate);
            Assert.IsNotNull(savedOrders[0].Customer);
            Assert.IsNotNull(savedOrders[0].Driver);
        }

        [TestMethod]
        public void SaveAndGetAllTest3()
        {
            Driver driver = new Driver()
            {
                FirstName = "Günther",
                LastName = "Horst",
                EmployeeNumber = 213,
                Areas = new List<Area>()
            };
            Area area = new Area()
            {
                Name = "Burgertown",
                Plz = 6543,
                Drivers = new List<Driver>()
                {
                    driver
                }
            };
            driver.Areas.Add(area);


            Order order1 = new Order()
            {
                OrderNumber = "23a",
                Description = "extra viel käse",
                OrderDate = DateTime.Parse("1999-05-01 05:08:12"),
                Customer = new Customer()
                {
                    FirstName = "Olaf",
                    LastName = "Burgereater",
                    City = "Burgertown",
                    Phone = "+4963254",
                    Plz = 59872,
                    Street = "Burgerstreet",
                    StreetNumber = "12a",
                    Type = 1
                },
                Driver = driver
            };

            Order order2 = new Order()
            {
                OrderNumber = "23c",
                Description = "extra wenig käse",
                OrderDate = DateTime.Parse("2048-05-01 07:08:12"),
                Customer = new Customer()
                {
                    FirstName = "Günther",
                    LastName = "Horst",
                    City = "Burgercity",
                    Phone = "+4965421",
                    Plz = 65412,
                    Street = "Burgergasse",
                    StreetNumber = "12y",
                    Type = 1
                },
                Driver = driver
            };

            mOrderRepository.Save(order1);
            mOrderRepository.Save(order2);

            List<Order> savedOrders = mOrderRepository.GetAll();

            Assert.AreEqual(2, savedOrders.Count);
            
            Assert.AreEqual("23a", savedOrders[0].OrderNumber);
            Assert.AreEqual("extra viel käse", savedOrders[0].Description);
            Assert.AreEqual(DateTime.Parse("1999-05-01 05:08:12"), savedOrders[0].OrderDate);
            Assert.IsNotNull(savedOrders[0].Customer);
            Assert.IsNotNull(savedOrders[0].Driver);

            Assert.AreEqual("23c", savedOrders[1].OrderNumber);
            Assert.AreEqual("extra wenig käse", savedOrders[1].Description);
            Assert.AreEqual(DateTime.Parse("2048-05-01 07:08:12"), savedOrders[1].OrderDate);
            Assert.IsNotNull(savedOrders[1].Customer);
            Assert.IsNotNull(savedOrders[1].Driver);
        }

        [TestMethod]
        public void SaveAndDeleteTest1()
        {
            Driver driver = new Driver()
            {
                FirstName = "Günther",
                LastName = "Horst",
                EmployeeNumber = 213,
                Areas = new List<Area>()
            };
            Area area = new Area()
            {
                Name = "Burgertown",
                Plz = 6543,
                Drivers = new List<Driver>()
                {
                    driver
                }
            };
            driver.Areas.Add(area);


            Order order1 = new Order()
            {
                OrderNumber = "23a",
                Description = "extra viel käse",
                OrderDate = DateTime.Parse("1999-05-01 05:08:12"),
                Customer = new Customer()
                {
                    FirstName = "Olaf",
                    LastName = "Burgereater",
                    City = "Burgertown",
                    Phone = "+4963254",
                    Plz = 59872,
                    Street = "Burgerstreet",
                    StreetNumber = "12a",
                    Type = 1
                },
                Driver = driver
            };

            Order order2 = new Order()
            {
                OrderNumber = "23c",
                Description = "extra wenig käse",
                OrderDate = DateTime.Parse("2048-05-01 07:08:12"),
                Customer = new Customer()
                {
                    FirstName = "Günther",
                    LastName = "Horst",
                    City = "Burgercity",
                    Phone = "+4965421",
                    Plz = 65412,
                    Street = "Burgergasse",
                    StreetNumber = "12y",
                    Type = 1
                },
                Driver = driver
            };

            mOrderRepository.Save(order1);
            mOrderRepository.Save(order2);

            mOrderRepository.Delete(order1);

            List<Order> savedOrders = mOrderRepository.GetAll();

            Assert.AreEqual(1, savedOrders.Count);

            Assert.AreEqual("23c", savedOrders[0].OrderNumber);
            Assert.AreEqual("extra wenig käse", savedOrders[0].Description);
            Assert.AreEqual(DateTime.Parse("2048-05-01 07:08:12"), savedOrders[0].OrderDate);
            Assert.IsNotNull(savedOrders[0].Customer);
            Assert.IsNotNull(savedOrders[0].Driver);
        }
    }
}
