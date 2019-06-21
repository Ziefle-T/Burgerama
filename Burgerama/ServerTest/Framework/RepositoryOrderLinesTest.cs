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
    public class RepositoryOrderLinesTest
    {
        private string databaseFile = AppContext.BaseDirectory + "\\TestDatabase\\BurgeramaX.db";
        private string databaseSourceFile = AppContext.BaseDirectory + "\\TestDatabase\\Burgerama.db";

        private NHibernateHelper mHibernateHelper;
        private Repository<OrderLines> mOrderLinesRepository;

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
            mOrderLinesRepository = new Repository<OrderLines>(mHibernateHelper);
        }

        [TestMethod]
        public void EmptyTest()
        {
            List<OrderLines> emptyOrderLinesList = mOrderLinesRepository.GetAll();

            Assert.AreEqual(0, emptyOrderLinesList.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest1()
        {
            Repository<Driver> driverRepository = new Repository<Driver>(mHibernateHelper);

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
                Driver = driver
            };

            OrderLines insertOrderLines = new OrderLines()
            {
                Amount = 5,
                Position = 2,
                Article = new Article()
                {
                    Name = "kaviarburger",
                    ArticleNumber = "123fa",
                    Description = "supa legga",
                    Price = 1.23M
                },
                Order = order
            };

            driverRepository.Save(driver);
            mOrderLinesRepository.Save(insertOrderLines);
            List<OrderLines> savedOrderLines = mOrderLinesRepository.GetAll();

            Assert.AreEqual(1, savedOrderLines.Count);
            OrderLines returnedOrderLine = savedOrderLines[0];
            Assert.AreEqual(insertOrderLines.Amount, returnedOrderLine.Amount);
            Assert.AreEqual(insertOrderLines.Position, returnedOrderLine.Position);

            Assert.AreEqual(insertOrderLines.Article.Name, returnedOrderLine.Article.Name);
            Assert.AreEqual(insertOrderLines.Article.ArticleNumber, returnedOrderLine.Article.ArticleNumber);
            Assert.AreEqual(insertOrderLines.Article.Description, returnedOrderLine.Article.Description);
            Assert.AreEqual(insertOrderLines.Article.Price, returnedOrderLine.Article.Price);

            Assert.AreEqual(insertOrderLines.Order.OrderNumber, returnedOrderLine.Order.OrderNumber);
            Assert.AreEqual(insertOrderLines.Order.Description, returnedOrderLine.Order.Description);
            Assert.AreEqual(insertOrderLines.Order.OrderDate, returnedOrderLine.Order.OrderDate);

            Assert.AreEqual(insertOrderLines.Order.Customer.FirstName, returnedOrderLine.Order.Customer.FirstName);
            Assert.AreEqual(insertOrderLines.Order.Customer.LastName, returnedOrderLine.Order.Customer.LastName);
            Assert.AreEqual(insertOrderLines.Order.Customer.City, returnedOrderLine.Order.Customer.City);
            Assert.AreEqual(insertOrderLines.Order.Customer.Phone, returnedOrderLine.Order.Customer.Phone);
            Assert.AreEqual(insertOrderLines.Order.Customer.Plz, returnedOrderLine.Order.Customer.Plz);
            Assert.AreEqual(insertOrderLines.Order.Customer.Street, returnedOrderLine.Order.Customer.Street);
            Assert.AreEqual(insertOrderLines.Order.Customer.StreetNumber, returnedOrderLine.Order.Customer.StreetNumber);
            Assert.AreEqual(insertOrderLines.Order.Customer.Type, returnedOrderLine.Order.Customer.Type);

            Assert.AreEqual(insertOrderLines.Order.Driver.FirstName, returnedOrderLine.Order.Driver.FirstName);
            Assert.AreEqual(insertOrderLines.Order.Driver.LastName, returnedOrderLine.Order.Driver.LastName);
            Assert.AreEqual(insertOrderLines.Order.Driver.EmployeeNumber, returnedOrderLine.Order.Driver.EmployeeNumber);
            Assert.AreEqual(insertOrderLines.Order.Driver.Areas.Count, returnedOrderLine.Order.Driver.Areas.Count);
            Assert.AreEqual(insertOrderLines.Order.Driver.Areas[0].Name, returnedOrderLine.Order.Driver.Areas[0].Name);
            Assert.AreEqual(insertOrderLines.Order.Driver.Areas[0].Plz, returnedOrderLine.Order.Driver.Areas[0].Plz);
            Assert.AreEqual(insertOrderLines.Order.Driver.Areas[0].Drivers.Count, returnedOrderLine.Order.Driver.Areas[0].Drivers.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest2()
        {
            Repository<Driver> driverRepository = new Repository<Driver>(mHibernateHelper);
            Repository<Area> areaRepository = new Repository<Area>(mHibernateHelper);
            Repository<Order> orderRepository = new Repository<Order>(mHibernateHelper);
            Repository<Customer> customerRepository = new Repository<Customer>(mHibernateHelper);
            Repository<Article> articleRepository = new Repository<Article>(mHibernateHelper);

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

            Article article = new Article()
            {
                Name = "kaviarburger",
                ArticleNumber = "123fa",
                Description = "supa legga",
                Price = 1.23M
            };

            OrderLines insertOrderLines = new OrderLines()
            {
                Amount = 5,
                Position = 2,
                Article = article,
                Order = order
            };

            driverRepository.Save(driver);
            mOrderLinesRepository.Save(insertOrderLines);

            List<Driver> savedDrivers = driverRepository.GetAll();
            List<Area> savedAreas = areaRepository.GetAll();
            List<Order> savedOrders = orderRepository.GetAll();
            List<Customer> savedCustomers = customerRepository.GetAll();
            List<Article> savedArticles = articleRepository.GetAll();

            Assert.AreEqual(1, savedArticles.Count);
            Assert.AreEqual(article.Name, savedArticles[0].Name);
            Assert.AreEqual(article.ArticleNumber, savedArticles[0].ArticleNumber);
            Assert.AreEqual(article.Description, savedArticles[0].Description);
            Assert.AreEqual(article.Price, savedArticles[0].Price);

            Assert.AreEqual(1, savedOrders.Count);
            Assert.AreEqual(order.OrderNumber, savedOrders[0].OrderNumber);
            Assert.AreEqual(order.Description, savedOrders[0].Description);
            Assert.AreEqual(order.OrderDate, savedOrders[0].OrderDate);

            Assert.AreEqual(customer.FirstName, savedCustomers[0].FirstName);
            Assert.AreEqual(customer.LastName, savedCustomers[0].LastName);
            Assert.AreEqual(customer.City, savedCustomers[0].City);
            Assert.AreEqual(customer.Phone, savedCustomers[0].Phone);
            Assert.AreEqual(customer.Plz, savedCustomers[0].Plz);
            Assert.AreEqual(customer.Street, savedCustomers[0].Street);
            Assert.AreEqual(customer.StreetNumber, savedCustomers[0].StreetNumber);
            Assert.AreEqual(customer.Type, savedCustomers[0].Type);

            Assert.AreEqual(driver.FirstName, savedDrivers[0].FirstName);
            Assert.AreEqual(driver.LastName, savedDrivers[0].LastName);
            Assert.AreEqual(driver.EmployeeNumber, savedDrivers[0].EmployeeNumber);
            Assert.AreEqual(driver.Areas.Count, savedDrivers[0].Areas.Count);
            Assert.AreEqual(driver.Areas[0].Name, savedDrivers[0].Areas[0].Name);
            Assert.AreEqual(driver.Areas[0].Plz, savedDrivers[0].Areas[0].Plz);
            Assert.AreEqual(driver.Areas[0].Drivers.Count, savedDrivers[0].Areas[0].Drivers.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest3()
        {
            Repository<Driver> driverRepository = new Repository<Driver>(mHibernateHelper);

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
            };

            OrderLines insertOrderLines1 = new OrderLines()
            {
                Amount = 5,
                Position = 2,
                Article = new Article()
                {
                    Name = "kaviarburger",
                    ArticleNumber = "123fa",
                    Description = "supa legga",
                    Price = 1.23M
                },
                Order = order
            };
            OrderLines insertOrderLines2 = new OrderLines()
            {
                Amount = 2,
                Position = 4,
                Article = new Article()
                {
                    Name = "burger²",
                    ArticleNumber = "68asf",
                    Description = "nigt so legga",
                    Price = 25.44M
                },
                Order = order
            };
            order.OrderLines.Add(insertOrderLines1);
            order.OrderLines.Add(insertOrderLines2);

            driverRepository.Save(driver);

            mOrderLinesRepository.Save(insertOrderLines1);
            mOrderLinesRepository.Save(insertOrderLines2);
            List<OrderLines> savedOrderLines = mOrderLinesRepository.GetAll();

            Assert.AreEqual(2, savedOrderLines.Count);
            OrderLines returnedOrderLine1 = savedOrderLines[1];
            OrderLines returnedOrderLine2 = savedOrderLines[0];
            Assert.AreEqual(insertOrderLines1.Amount, returnedOrderLine1.Amount);
            Assert.AreEqual(insertOrderLines1.Position, returnedOrderLine1.Position);

            Assert.AreEqual(insertOrderLines1.Article.Name, returnedOrderLine1.Article.Name);
            Assert.AreEqual(insertOrderLines1.Article.ArticleNumber, returnedOrderLine1.Article.ArticleNumber);
            Assert.AreEqual(insertOrderLines1.Article.Description, returnedOrderLine1.Article.Description);
            Assert.AreEqual(insertOrderLines1.Article.Price, returnedOrderLine1.Article.Price);

            Assert.AreEqual(insertOrderLines1.Order.OrderNumber, returnedOrderLine1.Order.OrderNumber);
            Assert.AreEqual(insertOrderLines1.Order.Description, returnedOrderLine1.Order.Description);
            Assert.AreEqual(insertOrderLines1.Order.OrderDate, returnedOrderLine1.Order.OrderDate);

            Assert.AreEqual(insertOrderLines1.Order.Customer.FirstName, returnedOrderLine1.Order.Customer.FirstName);
            Assert.AreEqual(insertOrderLines1.Order.Customer.LastName, returnedOrderLine1.Order.Customer.LastName);
            Assert.AreEqual(insertOrderLines1.Order.Customer.City, returnedOrderLine1.Order.Customer.City);
            Assert.AreEqual(insertOrderLines1.Order.Customer.Phone, returnedOrderLine1.Order.Customer.Phone);
            Assert.AreEqual(insertOrderLines1.Order.Customer.Plz, returnedOrderLine1.Order.Customer.Plz);
            Assert.AreEqual(insertOrderLines1.Order.Customer.Street, returnedOrderLine1.Order.Customer.Street);
            Assert.AreEqual(insertOrderLines1.Order.Customer.StreetNumber, returnedOrderLine1.Order.Customer.StreetNumber);
            Assert.AreEqual(insertOrderLines1.Order.Customer.Type, returnedOrderLine1.Order.Customer.Type);

            Assert.AreEqual(insertOrderLines1.Order.Driver.FirstName, returnedOrderLine1.Order.Driver.FirstName);
            Assert.AreEqual(insertOrderLines1.Order.Driver.LastName, returnedOrderLine1.Order.Driver.LastName);
            Assert.AreEqual(insertOrderLines1.Order.Driver.EmployeeNumber, returnedOrderLine1.Order.Driver.EmployeeNumber);
            Assert.AreEqual(insertOrderLines1.Order.Driver.Areas.Count, returnedOrderLine1.Order.Driver.Areas.Count);
            Assert.AreEqual(insertOrderLines1.Order.Driver.Areas[0].Name, returnedOrderLine1.Order.Driver.Areas[0].Name);
            Assert.AreEqual(insertOrderLines1.Order.Driver.Areas[0].Plz, returnedOrderLine1.Order.Driver.Areas[0].Plz);
            Assert.AreEqual(insertOrderLines1.Order.Driver.Areas[0].Drivers.Count, returnedOrderLine1.Order.Driver.Areas[0].Drivers.Count);

            Assert.AreEqual(insertOrderLines2.Amount, returnedOrderLine2.Amount);
            Assert.AreEqual(insertOrderLines2.Position, returnedOrderLine2.Position);

            Assert.AreEqual(insertOrderLines2.Article.Name, returnedOrderLine2.Article.Name);
            Assert.AreEqual(insertOrderLines2.Article.ArticleNumber, returnedOrderLine2.Article.ArticleNumber);
            Assert.AreEqual(insertOrderLines2.Article.Description, returnedOrderLine2.Article.Description);
            Assert.AreEqual(insertOrderLines2.Article.Price, returnedOrderLine2.Article.Price);

            Assert.AreEqual(insertOrderLines2.Order.OrderNumber, returnedOrderLine2.Order.OrderNumber);
            Assert.AreEqual(insertOrderLines2.Order.Description, returnedOrderLine2.Order.Description);
            Assert.AreEqual(insertOrderLines2.Order.OrderDate, returnedOrderLine2.Order.OrderDate);

            Assert.AreEqual(insertOrderLines2.Order.Customer.FirstName, returnedOrderLine2.Order.Customer.FirstName);
            Assert.AreEqual(insertOrderLines2.Order.Customer.LastName, returnedOrderLine2.Order.Customer.LastName);
            Assert.AreEqual(insertOrderLines2.Order.Customer.City, returnedOrderLine2.Order.Customer.City);
            Assert.AreEqual(insertOrderLines2.Order.Customer.Phone, returnedOrderLine2.Order.Customer.Phone);
            Assert.AreEqual(insertOrderLines2.Order.Customer.Plz, returnedOrderLine2.Order.Customer.Plz);
            Assert.AreEqual(insertOrderLines2.Order.Customer.Street, returnedOrderLine2.Order.Customer.Street);
            Assert.AreEqual(insertOrderLines2.Order.Customer.StreetNumber, returnedOrderLine2.Order.Customer.StreetNumber);
            Assert.AreEqual(insertOrderLines2.Order.Customer.Type, returnedOrderLine2.Order.Customer.Type);

            Assert.AreEqual(insertOrderLines2.Order.Driver.FirstName, returnedOrderLine2.Order.Driver.FirstName);
            Assert.AreEqual(insertOrderLines2.Order.Driver.LastName, returnedOrderLine2.Order.Driver.LastName);
            Assert.AreEqual(insertOrderLines2.Order.Driver.EmployeeNumber, returnedOrderLine2.Order.Driver.EmployeeNumber);
            Assert.AreEqual(insertOrderLines2.Order.Driver.Areas.Count, returnedOrderLine2.Order.Driver.Areas.Count);
            Assert.AreEqual(insertOrderLines2.Order.Driver.Areas[0].Name, returnedOrderLine2.Order.Driver.Areas[0].Name);
            Assert.AreEqual(insertOrderLines2.Order.Driver.Areas[0].Plz, returnedOrderLine2.Order.Driver.Areas[0].Plz);
            Assert.AreEqual(insertOrderLines2.Order.Driver.Areas[0].Drivers.Count, returnedOrderLine2.Order.Driver.Areas[0].Drivers.Count);
        }

        [TestMethod]
        public void SaveDeleteAndGetAllTest()
        {
            Repository<Driver> driverRepository = new Repository<Driver>(mHibernateHelper);

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
            };

            OrderLines insertOrderLines1 = new OrderLines()
            {
                Amount = 5,
                Position = 2,
                Article = new Article()
                {
                    Name = "kaviarburger",
                    ArticleNumber = "123fa",
                    Description = "supa legga",
                    Price = 1.23M
                },
                Order = order
            };
            OrderLines insertOrderLines2 = new OrderLines()
            {
                Amount = 2,
                Position = 4,
                Article = new Article()
                {
                    Name = "burger²",
                    ArticleNumber = "68asf",
                    Description = "nigt so legga",
                    Price = 25.44M
                },
                Order = order
            };
            order.OrderLines.Add(insertOrderLines1);
            order.OrderLines.Add(insertOrderLines2);

            driverRepository.Save(driver);

            mOrderLinesRepository.Save(insertOrderLines1);
            mOrderLinesRepository.Save(insertOrderLines2);

            mOrderLinesRepository.Delete(insertOrderLines1);

            List<OrderLines> savedOrderLines = mOrderLinesRepository.GetAll();

            Assert.AreEqual(1, savedOrderLines.Count);
            OrderLines returnedOrderLine2 = savedOrderLines[0];
            Assert.AreEqual(insertOrderLines2.Amount, returnedOrderLine2.Amount);
            Assert.AreEqual(insertOrderLines2.Position, returnedOrderLine2.Position);

            Assert.AreEqual(insertOrderLines2.Article.Name, returnedOrderLine2.Article.Name);
            Assert.AreEqual(insertOrderLines2.Article.ArticleNumber, returnedOrderLine2.Article.ArticleNumber);
            Assert.AreEqual(insertOrderLines2.Article.Description, returnedOrderLine2.Article.Description);
            Assert.AreEqual(insertOrderLines2.Article.Price, returnedOrderLine2.Article.Price);

            Assert.AreEqual(insertOrderLines2.Order.OrderNumber, returnedOrderLine2.Order.OrderNumber);
            Assert.AreEqual(insertOrderLines2.Order.Description, returnedOrderLine2.Order.Description);
            Assert.AreEqual(insertOrderLines2.Order.OrderDate, returnedOrderLine2.Order.OrderDate);

            Assert.AreEqual(insertOrderLines2.Order.Customer.FirstName, returnedOrderLine2.Order.Customer.FirstName);
            Assert.AreEqual(insertOrderLines2.Order.Customer.LastName, returnedOrderLine2.Order.Customer.LastName);
            Assert.AreEqual(insertOrderLines2.Order.Customer.City, returnedOrderLine2.Order.Customer.City);
            Assert.AreEqual(insertOrderLines2.Order.Customer.Phone, returnedOrderLine2.Order.Customer.Phone);
            Assert.AreEqual(insertOrderLines2.Order.Customer.Plz, returnedOrderLine2.Order.Customer.Plz);
            Assert.AreEqual(insertOrderLines2.Order.Customer.Street, returnedOrderLine2.Order.Customer.Street);
            Assert.AreEqual(insertOrderLines2.Order.Customer.StreetNumber, returnedOrderLine2.Order.Customer.StreetNumber);
            Assert.AreEqual(insertOrderLines2.Order.Customer.Type, returnedOrderLine2.Order.Customer.Type);

            Assert.AreEqual(insertOrderLines2.Order.Driver.FirstName, returnedOrderLine2.Order.Driver.FirstName);
            Assert.AreEqual(insertOrderLines2.Order.Driver.LastName, returnedOrderLine2.Order.Driver.LastName);
            Assert.AreEqual(insertOrderLines2.Order.Driver.EmployeeNumber, returnedOrderLine2.Order.Driver.EmployeeNumber);
            Assert.AreEqual(insertOrderLines2.Order.Driver.Areas.Count, returnedOrderLine2.Order.Driver.Areas.Count);
            Assert.AreEqual(insertOrderLines2.Order.Driver.Areas[0].Name, returnedOrderLine2.Order.Driver.Areas[0].Name);
            Assert.AreEqual(insertOrderLines2.Order.Driver.Areas[0].Plz, returnedOrderLine2.Order.Driver.Areas[0].Plz);
            Assert.AreEqual(insertOrderLines2.Order.Driver.Areas[0].Drivers.Count, returnedOrderLine2.Order.Driver.Areas[0].Drivers.Count);
        }
    }
}
