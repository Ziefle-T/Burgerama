using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Server.Framework;

namespace Server.Services
{
    abstract public class UpdatableService<T> where T : class
    {
        protected IRepository<T> mRepository;

        public UpdatableService(IRepository<T> repository)
        {
            mRepository = repository;
        }

        public virtual List<T> GetAll()
        {
            return mRepository.GetAll();
        }

        public virtual bool Add(T obj)
        {
            try
            {
                mRepository.Save(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public virtual bool Delete(int id)
        {
            try
            {
                T obj = GetElementById(id);
                
                if (obj == null)
                {
                    return false;
                }
                
                mRepository.Delete(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// 0 = OK
        /// 1 = Other Error
        /// 2 = Versioning Error
        /// 3 = No old Element
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected virtual int UpdateElement(int id, T obj)
        {
            try
            {
                T oldObj = GetElementById(id);

                if (oldObj == null)
                {
                    return 3;
                }

                mRepository.Save(obj);
                return 0;
            }
            catch (StaleObjectStateException e)
            {
                Console.WriteLine(e);
                return 2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
        }

        protected virtual bool Update(int id, Action<T> act)
        {
            try
            {
                T obj = GetElementById(id);

                if (obj == null)
                {
                    return false;
                }

                act.Invoke(obj);
                mRepository.Save(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public abstract T GetElementById(int id);
    }
}
