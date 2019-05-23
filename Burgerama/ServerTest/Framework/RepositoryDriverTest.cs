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
    public class RepositoryDriverTest
    {
        private string databaseFile = AppContext.BaseDirectory + "\\TestDatabase\\BurgeramaX.db";
        private string databaseSourceFile = AppContext.BaseDirectory + "\\TestDatabase\\Burgerama.db";

        private NHibernateHelper mHibernateHelper;
        private Repository<Driver> mDriverRepository;

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
            mDriverRepository = new Repository<Driver>(mHibernateHelper);
        }

        [TestMethod]
        public void EmptyTest()
        {
            List<Driver> emptyDriverList = mDriverRepository.GetAll();

            Assert.AreEqual(0, emptyDriverList.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest1()
        {
            Driver insertDriver = new Driver()
            {
                FirstName = "anton",
                LastName = "müller",
                EmployeeNumber = 843,
                Areas = new List<Area>()
            };

            mDriverRepository.Save(insertDriver);
            List<Driver> savedDrivers = mDriverRepository.GetAll();

            Assert.AreEqual(1, savedDrivers.Count);
            Driver returnedDriver = savedDrivers[0];
            Assert.AreEqual(insertDriver.FirstName, returnedDriver.FirstName);
            Assert.AreEqual(insertDriver.LastName, returnedDriver.LastName);
            Assert.AreEqual(insertDriver.EmployeeNumber, returnedDriver.EmployeeNumber);
            Assert.AreEqual(0, returnedDriver.Areas.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest2()
        {
            Area area1 = new Area()
            {
                Name = "Horb",
                Plz = 8645,
                Drivers = new List<Driver>()
            };

            Driver insertDriver = new Driver()
            {
                FirstName = "anton",
                LastName = "müller",
                EmployeeNumber = 843,
                Areas = new List<Area>()
                {
                    area1
                }
            };
            area1.Drivers.Add(insertDriver);

            mDriverRepository.Save(insertDriver);
            List<Driver> savedDrivers = mDriverRepository.GetAll();

            Assert.AreEqual(1, savedDrivers.Count);
            Driver returnedDriver = savedDrivers[0];
            Assert.AreEqual(insertDriver.FirstName, returnedDriver.FirstName);
            Assert.AreEqual(insertDriver.LastName, returnedDriver.LastName);
            Assert.AreEqual(insertDriver.EmployeeNumber, returnedDriver.EmployeeNumber);

            Assert.AreEqual(1, returnedDriver.Areas.Count);
            Assert.AreEqual(area1.Name, returnedDriver.Areas[0].Name);
            Assert.AreEqual(area1.Plz, returnedDriver.Areas[0].Plz);
            Assert.AreEqual(1, returnedDriver.Areas[0].Drivers.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest3()
        {
            Area area1 = new Area()
            {
                Name = "Horb",
                Plz = 8645,
                Drivers = new List<Driver>()
            };
            Area area2 = new Area()
            {
                Name = "Stuttgart",
                Plz = 3564,
                Drivers = new List<Driver>()
            };

            Driver insertDriver = new Driver()
            {
                FirstName = "anton",
                LastName = "müller",
                EmployeeNumber = 843,
                Areas = new List<Area>()
                {
                    area1,
                    area2
                }
            };
            area1.Drivers.Add(insertDriver);
            area2.Drivers.Add(insertDriver);

            mDriverRepository.Save(insertDriver);
            List<Driver> savedDrivers = mDriverRepository.GetAll();

            Assert.AreEqual(1, savedDrivers.Count);
            Driver returnedDriver = savedDrivers[0];
            Assert.AreEqual(insertDriver.FirstName, returnedDriver.FirstName);
            Assert.AreEqual(insertDriver.LastName, returnedDriver.LastName);
            Assert.AreEqual(insertDriver.EmployeeNumber, returnedDriver.EmployeeNumber);

            Assert.AreEqual(2, returnedDriver.Areas.Count);
            Assert.AreEqual(area1.Name, returnedDriver.Areas[0].Name);
            Assert.AreEqual(area1.Plz, returnedDriver.Areas[0].Plz);
            Assert.AreEqual(1, returnedDriver.Areas[0].Drivers.Count);

            Assert.AreEqual(area2.Name, returnedDriver.Areas[1].Name);
            Assert.AreEqual(area2.Plz, returnedDriver.Areas[1].Plz);
            Assert.AreEqual(1, returnedDriver.Areas[1].Drivers.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest4()
        {
            Area area1 = new Area()
            {
                Name = "Horb",
                Plz = 8645,
                Drivers = new List<Driver>()
            };
            Area area2 = new Area()
            {
                Name = "Stuttgart",
                Plz = 3564,
                Drivers = new List<Driver>()
            };

            Driver insertDriver1 = new Driver()
            {
                FirstName = "anton",
                LastName = "müller",
                EmployeeNumber = 843,
                Areas = new List<Area>()
                {
                    area1,
                    area2
                }
            };

            Driver insertDriver2 = new Driver()
            {
                FirstName = "horst",
                LastName = "grün",
                EmployeeNumber = 543,
                Areas = new List<Area>()
                {
                    area1,
                    area2
                }
            };

            area1.Drivers.Add(insertDriver1);
            area1.Drivers.Add(insertDriver2);
            area2.Drivers.Add(insertDriver1);
            area2.Drivers.Add(insertDriver2);

            mDriverRepository.Save(insertDriver1);
            mDriverRepository.Save(insertDriver2);
            List<Driver> savedDrivers = mDriverRepository.GetAll();

            Assert.AreEqual(2, savedDrivers.Count);
            Driver returnedDriver1 = savedDrivers[0];
            Assert.AreEqual(insertDriver1.FirstName, returnedDriver1.FirstName);
            Assert.AreEqual(insertDriver1.LastName, returnedDriver1.LastName);
            Assert.AreEqual(insertDriver1.EmployeeNumber, returnedDriver1.EmployeeNumber);

            Assert.AreEqual(2, returnedDriver1.Areas.Count);
            Assert.AreEqual(area1.Name, returnedDriver1.Areas[0].Name);
            Assert.AreEqual(area1.Plz, returnedDriver1.Areas[0].Plz);
            Assert.AreEqual(2, returnedDriver1.Areas[0].Drivers.Count);

            Assert.AreEqual(area2.Name, returnedDriver1.Areas[1].Name);
            Assert.AreEqual(area2.Plz, returnedDriver1.Areas[1].Plz);
            Assert.AreEqual(2, returnedDriver1.Areas[1].Drivers.Count);

            Driver returnedDriver2 = savedDrivers[1];
            Assert.AreEqual(insertDriver2.FirstName, returnedDriver2.FirstName);
            Assert.AreEqual(insertDriver2.LastName, returnedDriver2.LastName);
            Assert.AreEqual(insertDriver2.EmployeeNumber, returnedDriver2.EmployeeNumber);

            Assert.AreEqual(2, returnedDriver2.Areas.Count);
            Assert.AreEqual(area1.Name, returnedDriver2.Areas[0].Name);
            Assert.AreEqual(area1.Plz, returnedDriver2.Areas[0].Plz);
            Assert.AreEqual(2, returnedDriver2.Areas[0].Drivers.Count);

            Assert.AreEqual(area2.Name, returnedDriver2.Areas[1].Name);
            Assert.AreEqual(area2.Plz, returnedDriver2.Areas[1].Plz);
            Assert.AreEqual(2, returnedDriver2.Areas[1].Drivers.Count);
        }

        [TestMethod]
        public void SaveDeleteAndGetAllTest1()
        {
            Driver insertDriver1 = new Driver()
            {
                FirstName = "anton",
                LastName = "müller",
                EmployeeNumber = 843,
                Areas = new List<Area>()
            };

            Driver insertDriver2 = new Driver()
            {
                FirstName = "horst",
                LastName = "silber",
                EmployeeNumber = 984,
                Areas = new List<Area>()
            };

            mDriverRepository.Save(insertDriver1);
            mDriverRepository.Save(insertDriver2);

            mDriverRepository.Delete(insertDriver1);

            List<Driver> savedDrivers = mDriverRepository.GetAll();

            Assert.AreEqual(1, savedDrivers.Count);
            Driver returnedDriver = savedDrivers[0];
            Assert.AreEqual(insertDriver2.FirstName, returnedDriver.FirstName);
            Assert.AreEqual(insertDriver2.LastName, returnedDriver.LastName);
            Assert.AreEqual(insertDriver2.EmployeeNumber, returnedDriver.EmployeeNumber);
            Assert.AreEqual(0, returnedDriver.Areas.Count);
        }
    }
}
