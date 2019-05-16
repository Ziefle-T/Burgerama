using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Server.Framework
{
    class NHibernateHelper : INHibernateHelper
    {
        private ISessionFactory mSessionFactory;
        private string mDatabaseFile;

        public ISessionFactory SessionFactory
        {
            get
            {
                if (mSessionFactory == null)
                    InitializeSessionFactory();
                return mSessionFactory;
            }
        }

        public NHibernateHelper(string databaseFile = "Database\\Burgerama.db")
        {
            this.mDatabaseFile = databaseFile;
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private void InitializeSessionFactory()
        {
            mSessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(mDatabaseFile).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                .BuildSessionFactory();
        }
    }
}
