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
    public class RepositoryUserTest
    {
        private string databaseFile = AppContext.BaseDirectory + "\\TestDatabase\\BurgeramaX.db";
        private string databaseSourceFile = AppContext.BaseDirectory + "\\TestDatabase\\Burgerama.db";

        private NHibernateHelper mHibernateHelper;
        private Repository<User> mUserRepository;

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
            mUserRepository = new Repository<User>(mHibernateHelper);
        }

        [TestMethod]
        public void EmptyTest()
        {
            List<User> returnedUsers = mUserRepository.GetAll();

            Assert.AreEqual(3, returnedUsers.Count);

            Assert.AreEqual("admin", returnedUsers[0].Username);
            Assert.IsNull(returnedUsers[0].Firstname);
            Assert.AreEqual("Administrator", returnedUsers[0].Lastname);
            Assert.AreEqual("$2a$10$RHHksIFEhEQT1RMbUFUfAuE1L36crWGK7wu0SwdY3Fkwq.q9.I4Me", returnedUsers[0].Password);
            Assert.AreEqual(true, returnedUsers[0].IsAdmin);

            Assert.AreEqual("horst", returnedUsers[1].Username);
            Assert.AreEqual("Horst", returnedUsers[1].Firstname);
            Assert.AreEqual("Müller", returnedUsers[1].Lastname);
            Assert.AreEqual("$2a$10$YcsmJTxvWHdg1pG4pXy4mOVfXrnUDo7hpcwbu85RZbDNsa4KeqEHC", returnedUsers[1].Password);
            Assert.AreEqual(false, returnedUsers[1].IsAdmin);

            Assert.AreEqual("frank", returnedUsers[2].Username);
            Assert.AreEqual("Frank", returnedUsers[2].Firstname);
            Assert.AreEqual("Meyer", returnedUsers[2].Lastname);
            Assert.AreEqual("$2a$10$Kcj5sQps/Kt86dQ/L4dFiOZHLXFpC9tk.uJiEQxtFHLDKyDEdSj8q", returnedUsers[2].Password);
            Assert.AreEqual(false, returnedUsers[2].IsAdmin);
        }

        [TestMethod]
        public void SaveAndGetAllTest1()
        {
            User user = new User()
            {
                Username = "skankhunt42",
                Firstname = "Günther",
                Lastname = "Bernd",
                Password = "aspiduhga",
                IsAdmin = false
            };

            mUserRepository.Save(user);

            List<User> returnedUsers = mUserRepository.GetAll();
            Assert.AreEqual(4, returnedUsers.Count);
            Assert.AreEqual("skankhunt42", returnedUsers[3].Username);
            Assert.AreEqual("Günther", returnedUsers[3].Firstname);
            Assert.AreEqual("Bernd", returnedUsers[3].Lastname);
            Assert.AreEqual("aspiduhga", returnedUsers[3].Password);
            Assert.AreEqual(false, returnedUsers[3].IsAdmin);
        }

        [TestMethod]
        public void SaveAndGetAllTest2()
        {
            User user1 = new User()
            {
                Username = "skankhunt42",
                Firstname = "Günther",
                Lastname = "Bernd",
                Password = "aspiduhga",
                IsAdmin = false
            };

            User user2 = new User()
            {
                Username = "bröner",
                Firstname = "Ursula",
                Lastname = "Grün",
                Password = "wertiuqwer",
                IsAdmin = true
            };

            mUserRepository.Save(user1);
            mUserRepository.Save(user2);

            List<User> returnedUsers = mUserRepository.GetAll();
            Assert.AreEqual(5, returnedUsers.Count);
            Assert.AreEqual("skankhunt42", returnedUsers[3].Username);
            Assert.AreEqual("Günther", returnedUsers[3].Firstname);
            Assert.AreEqual("Bernd", returnedUsers[3].Lastname);
            Assert.AreEqual("aspiduhga", returnedUsers[3].Password);
            Assert.AreEqual(false, returnedUsers[3].IsAdmin);

            Assert.AreEqual("bröner", returnedUsers[4].Username);
            Assert.AreEqual("Ursula", returnedUsers[4].Firstname);
            Assert.AreEqual("Grün", returnedUsers[4].Lastname);
            Assert.AreEqual("wertiuqwer", returnedUsers[4].Password);
            Assert.AreEqual(true, returnedUsers[4].IsAdmin);
        }
    }
}
