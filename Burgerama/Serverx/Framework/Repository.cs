using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;

namespace Server.Framework
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private INHibernateHelper mNHibernateHelper;

        public Repository(INHibernateHelper nHibernateHelper)
        {
            this.mNHibernateHelper = nHibernateHelper;
        }

        public List<T> GetAll()
        {
            using (var session = mNHibernateHelper.OpenSession())
            {
                var returnList = session.CreateCriteria<T>().List<T>();
                return returnList as List<T>;
            }
        }

        public List<T> GetAllWhere(Expression<Func<T, bool>> whereExpression)
        {
            using (var session = mNHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<T>().Where(whereExpression).List<T>();
                return returnList as List<T>;
            }
        }

        public void Delete(T entity)
        {
            using (var session = mNHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        public void Save(T entity)
        {
            using (var session = mNHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }
    }
}
