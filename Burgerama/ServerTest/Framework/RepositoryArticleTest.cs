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
    public class RepositoryArticleTest
    {
        private string databaseFile = AppContext.BaseDirectory + "\\TestDatabase\\BurgeramaX.db";
        private string databaseSourceFile = AppContext.BaseDirectory + "\\TestDatabase\\Burgerama.db";

        private NHibernateHelper mHibernateHelper;
        private Repository<Article> mArticleRepository;

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
            mArticleRepository = new Repository<Article>(mHibernateHelper);
        }

        [TestMethod]
        public void EmptyTest()
        {
            List<Article> emptyArticleList = mArticleRepository.GetAll();

            Assert.AreEqual(0, emptyArticleList.Count);
        }

        [TestMethod]
        public void SaveAndGetAllTest1()
        {
            Article insertArticle = new Article()
            {
                ArticleNumber = "123",
                Description = "Article1 Description",
                Name = "Article1",
                Price = 5.93M
            };

            mArticleRepository.Save(insertArticle);
            List<Article> savedArticles = mArticleRepository.GetAll();

            Assert.AreEqual(1, savedArticles.Count);
            Article returnedArticle = savedArticles[0];
            Assert.AreEqual(insertArticle.ArticleNumber, returnedArticle.ArticleNumber);
            Assert.AreEqual(insertArticle.Description, returnedArticle.Description);
            Assert.AreEqual(insertArticle.Name, returnedArticle.Name);
            Assert.AreEqual(insertArticle.Price, returnedArticle.Price);
        }

        [TestMethod]
        public void SaveAndGetAllTest2()
        {
            Article insertArticle1 = new Article()
            {
                ArticleNumber = "123",
                Description = "Article1 Description",
                Name = "Article1",
                Price = 5.93M
            };
            Article insertArticle2 = new Article()
            {
                ArticleNumber = "423",
                Description = "Article2 Description",
                Name = "Article2",
                Price = 6.72M
            };

            mArticleRepository.Save(insertArticle1);
            mArticleRepository.Save(insertArticle2);
            List<Article> savedArticles = mArticleRepository.GetAll();

            Assert.AreEqual(2, savedArticles.Count);
            Article returnedArticle1 = savedArticles[0];
            Assert.AreEqual(insertArticle1.ArticleNumber, returnedArticle1.ArticleNumber);
            Assert.AreEqual(insertArticle1.Description, returnedArticle1.Description);
            Assert.AreEqual(insertArticle1.Name, returnedArticle1.Name);
            Assert.AreEqual(insertArticle1.Price, returnedArticle1.Price);

            Article returnedArticle2 = savedArticles[1];
            Assert.AreEqual(insertArticle2.ArticleNumber, returnedArticle2.ArticleNumber);
            Assert.AreEqual(insertArticle2.Description, returnedArticle2.Description);
            Assert.AreEqual(insertArticle2.Name, returnedArticle2.Name);
            Assert.AreEqual(insertArticle2.Price, returnedArticle2.Price);
        }

        [TestMethod]
        public void BreakUniqueArticleNumberConstraintTest()
        {
            Article insertArticle1 = new Article()
            {
                ArticleNumber = "123",
                Description = "Article1 Description",
                Name = "Article1",
                Price = 5.93M
            };
            Article insertArticle2 = new Article()
            {
                ArticleNumber = "123",
                Description = "Article2 Description",
                Name = "Article2",
                Price = 6.72M
            };

            mArticleRepository.Save(insertArticle1);

            Assert.ThrowsException<GenericADOException>(() => mArticleRepository.Save(insertArticle2));
        }

        [TestMethod]
        public void SaveDeleteAndGetAllTest1()
        {
            Article insertArticle1 = new Article()
            {
                ArticleNumber = "123",
                Description = "Article1 Description",
                Name = "Article1",
                Price = 5.93M
            };
            Article insertArticle2 = new Article()
            {
                ArticleNumber = "423",
                Description = "Article2 Description",
                Name = "Article2",
                Price = 6.72M
            };

            mArticleRepository.Save(insertArticle1);
            mArticleRepository.Save(insertArticle2);

            mArticleRepository.Delete(insertArticle1);

            List<Article> savedArticles = mArticleRepository.GetAll();

            Assert.AreEqual(1, savedArticles.Count);
            Article returnedArticle1 = savedArticles[0];
            
            Assert.AreEqual(insertArticle2.ArticleNumber, returnedArticle1.ArticleNumber);
            Assert.AreEqual(insertArticle2.Description, returnedArticle1.Description);
            Assert.AreEqual(insertArticle2.Name, returnedArticle1.Name);
            Assert.AreEqual(insertArticle2.Price, returnedArticle1.Price);
        }
    }
}
