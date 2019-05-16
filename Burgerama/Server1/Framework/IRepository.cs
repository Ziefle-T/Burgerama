using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NHibernate.Event;

namespace Server.Framework
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAllWhere(Expression<Func<T, bool>> whereExpression);
        void Delete(T entity);
        void Save(T entity);
    }
}