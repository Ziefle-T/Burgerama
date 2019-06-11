﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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

        protected virtual bool UpdateElement(int id, T obj)
        {
            try
            {
                T oldObj = GetElementById(id);

                if (oldObj == null)
                {
                    return false;
                }
                
                mRepository.Save(obj);
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
