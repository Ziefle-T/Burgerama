using NHibernate;

namespace Server.Framework
{
    public interface INHibernateHelper
    {
        ISessionFactory SessionFactory { get; }
        ISession OpenSession();
    }
}