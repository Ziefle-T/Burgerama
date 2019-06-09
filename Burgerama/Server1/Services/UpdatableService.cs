using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                T obj = mRepository.GetAllWhere(x => EqualsId(x, id)).FirstOrDefault();

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

        protected virtual bool Update(int id, Action<T> act)
        {
            try
            {
                T obj = mRepository.GetAllWhere(x => EqualsId(x, id)).FirstOrDefault();

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

        protected abstract bool EqualsId(T obj, int id);
    }
}
