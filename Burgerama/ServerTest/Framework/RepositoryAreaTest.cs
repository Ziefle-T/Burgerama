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
    public class RepositoryAreaTest
    {
        private string databaseFile = AppContext.BaseDirectory + "\\TestDatabase\\BurgeramaX.db";
        private string databaseSourceFile = AppContext.BaseDirectory + "\\TestDatabase\\Burgerama.db";

        private NHibernateHelper mHibernateHelper;
        private Repository<Area> mAreaRepository;

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
            mAreaRepository = new Repository<Area>(mHibernateHelper);
        }

        [TestMethod]
        public void EmptyTest()
        {
            List<Area> emptyAreaList = mAreaRepository.GetAll();

            Assert.AreEqual(0, emptyAreaList.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest1()
        {
            Area insertArea = new Area()
            {
                Name = "TestName",
                Plz = 8234,
                Drivers = new List<Driver>()
            };

            mAreaRepository.Save(insertArea);
            List<Area> savedAreas = mAreaRepository.GetAll();

            Assert.AreEqual(1, savedAreas.Count);
            Area returnedArea = savedAreas[0];
            Assert.AreEqual(insertArea.Name, returnedArea.Name);
            Assert.AreEqual(insertArea.Plz, returnedArea.Plz);
            Assert.AreEqual(insertArea.Drivers.Count, returnedArea.Drivers.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest2()
        {
            Repository<Driver> driveRepository = new Repository<Driver>(mHibernateHelper);

            Driver driver1 = new Driver()
            {
                FirstName = "Olaf",
                LastName = "Detlef",
                EmployeeNumber = 1,
                Areas = new List<Area>()
            };

            Area insertArea = new Area()
            {
                Name = "TestName",
                Plz = 8234,
                Drivers = new List<Driver>()
                {
                    driver1      
                }
            };

            driver1.Areas.Add(insertArea);

            driveRepository.Save(driver1);
            
            List<Area> savedAreas = mAreaRepository.GetAll();

            Assert.AreEqual(1, savedAreas.Count);
            Area returnedArea = savedAreas[0];
            Assert.AreEqual(insertArea.Name, returnedArea.Name);
            Assert.AreEqual(insertArea.Plz, returnedArea.Plz);
            Assert.AreEqual(insertArea.Drivers.Count, returnedArea.Drivers.Count);
            
            Assert.AreEqual(driver1.FirstName, returnedArea.Drivers[0].FirstName);
            Assert.AreEqual(driver1.LastName, returnedArea.Drivers[0].LastName);
            Assert.AreEqual(driver1.EmployeeNumber, returnedArea.Drivers[0].EmployeeNumber);
            Assert.AreEqual(1, returnedArea.Drivers[0].Areas.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest3()
        {
            Repository<Driver> driverRepository = new Repository<Driver>(mHibernateHelper);

            Driver driver1 = new Driver()
            {
                FirstName = "Olaf",
                LastName = "Detlef",
                EmployeeNumber = 1,
                Areas = new List<Area>()
            };

            Driver driver2 = new Driver()
            {
                FirstName = "Antonius",
                LastName = "Helmut",
                EmployeeNumber = 2,
                Areas = new List<Area>()
            };

            Area insertArea = new Area()
            {
                Name = "TestName",
                Plz = 8234,
                Drivers = new List<Driver>()
                {
                    driver1,
                    driver2
                }
            };

            driver1.Areas.Add(insertArea);
            driver2.Areas.Add(insertArea);

            driverRepository.Save(driver1);
            driverRepository.Save(driver2);
            
            List<Area> savedAreas = mAreaRepository.GetAll();

            Assert.AreEqual(1, savedAreas.Count);
            Area returnedArea = savedAreas[0];
            Assert.AreEqual(insertArea.Name, returnedArea.Name);
            Assert.AreEqual(insertArea.Plz, returnedArea.Plz);

            Assert.AreEqual(insertArea.Drivers.Count, returnedArea.Drivers.Count);

            Assert.AreEqual(driver1.FirstName, returnedArea.Drivers[0].FirstName);
            Assert.AreEqual(driver1.LastName, returnedArea.Drivers[0].LastName);
            Assert.AreEqual(driver1.EmployeeNumber, returnedArea.Drivers[0].EmployeeNumber);
            Assert.AreEqual(1, returnedArea.Drivers[0].Areas.Count);

            Assert.AreEqual(driver2.FirstName, returnedArea.Drivers[1].FirstName);
            Assert.AreEqual(driver2.LastName, returnedArea.Drivers[1].LastName);
            Assert.AreEqual(driver2.EmployeeNumber, returnedArea.Drivers[1].EmployeeNumber);
            Assert.AreEqual(1, returnedArea.Drivers[1].Areas.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest4()
        {
            Repository<Driver> driverRepository = new Repository<Driver>(mHibernateHelper);

            Driver driver = new Driver()
            {
                FirstName = "Olaf",
                LastName = "Detlef",
                EmployeeNumber = 1,
                Areas = new List<Area>()
            };

            Area area1 = new Area()
            {
                Name = "TestName",
                Plz = 8234,
                Drivers = new List<Driver>()
                {
                    driver
                }
            };

            Area area2 = new Area()
            {
                Name = "TestName2",
                Plz = 8235,
                Drivers = new List<Driver>()
                {
                    driver
                }
            };

            driver.Areas.Add(area1);
            driver.Areas.Add(area2);

            driverRepository.Save(driver);
            
            List<Area> savedAreas = mAreaRepository.GetAll();

            Assert.AreEqual(2, savedAreas.Count);
            Area returnedArea1 = savedAreas[0];
            Area returnedArea2 = savedAreas[1];

            Assert.AreEqual(area1.Name, returnedArea1.Name);
            Assert.AreEqual(area1.Plz, returnedArea1.Plz);

            Assert.AreEqual(area2.Name, returnedArea2.Name);
            Assert.AreEqual(area2.Plz, returnedArea2.Plz);

            Assert.AreEqual(area1.Drivers.Count, returnedArea1.Drivers.Count);
            Assert.AreEqual(area2.Drivers.Count, returnedArea2.Drivers.Count);

            Assert.AreEqual(driver.FirstName, returnedArea1.Drivers[0].FirstName);
            Assert.AreEqual(driver.LastName, returnedArea1.Drivers[0].LastName);
            Assert.AreEqual(driver.EmployeeNumber, returnedArea1.Drivers[0].EmployeeNumber);
            Assert.AreEqual(2, returnedArea1.Drivers[0].Areas.Count);

            Assert.AreEqual(driver.FirstName, returnedArea2.Drivers[0].FirstName);
            Assert.AreEqual(driver.LastName, returnedArea2.Drivers[0].LastName);
            Assert.AreEqual(driver.EmployeeNumber, returnedArea2.Drivers[0].EmployeeNumber);
            Assert.AreEqual(2, returnedArea2.Drivers[0].Areas.Count);
        }

        [TestMethod]
        public void SaveDeleteAndGetAllTest()
        {
            Repository<Driver> driverRepository = new Repository<Driver>(mHibernateHelper);

            Driver driver = new Driver()
            {
                FirstName = "Olaf",
                LastName = "Detlef",
                EmployeeNumber = 1,
                Areas = new List<Area>()
            };

            Area area1 = new Area()
            {
                Name = "TestName",
                Plz = 8234,
                Drivers = new List<Driver>()
                {
                    driver
                }
            };

            Area area2 = new Area()
            {
                Name = "TestName2",
                Plz = 8235,
                Drivers = new List<Driver>()
                {
                    driver
                }
            };

            driver.Areas.Add(area1);
            driver.Areas.Add(area2);

            driverRepository.Save(driver);

            area1.Delete(driverRepository, mAreaRepository);
            
            List<Area> savedAreas = mAreaRepository.GetAll();

            Assert.AreEqual(1, savedAreas.Count);
            Area returnedArea1 = savedAreas[0];

            Assert.AreEqual(area2.Name, returnedArea1.Name);
            Assert.AreEqual(area2.Plz, returnedArea1.Plz);
                                
            Assert.AreEqual(area2.Drivers.Count, returnedArea1.Drivers.Count);

            Assert.AreEqual(driver.FirstName, returnedArea1.Drivers[0].FirstName);
            Assert.AreEqual(driver.LastName, returnedArea1.Drivers[0].LastName);
            Assert.AreEqual(driver.EmployeeNumber, returnedArea1.Drivers[0].EmployeeNumber);
            Assert.AreEqual(1, returnedArea1.Drivers[0].Areas.Count);
        }
    }
}
