﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using NHibernate;
using Server.Framework;
using Server.Models;

namespace Server.Services
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "UserService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class UserService : UpdatableService<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository) {}

        public override bool Add(User user)
        {
            user.SetNewPassword("geheim");
            return base.Add(user);
        }

        public override List<User> GetAll()
        {
            List<User> users = base.GetAll();
            users.ForEach(x => x.Password = null);

            return users;
        }

        public (bool success, User user) Login(string userName, string password)
        {
            try
            {
                User user = mRepository.GetAllWhere(x => x.Username == userName).FirstOrDefault();

                if (user == null)
                {
                    return (false, null);
                }

                bool success = user.ValidatePw(password);

                user.Password = null;

                return (success, user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null);
            }
        }

        public bool UpdateAdmin(int userId, bool isAdmin)
        {
            return Update(userId, x => x.IsAdmin = isAdmin);
        }

        public bool UpdateFirstname(int userId, string firstname)
        {
            return Update(userId, x => x.Firstname = firstname);
        }

        public bool UpdateLastname(int userId, string lastname)
        {
            return Update(userId, x => x.Lastname = lastname);
        }

        public int UpdatePassword(int userId, string oldPassword, string password)
        {
            try
            {
                User user = mRepository.GetAllWhere(x => x.Id == userId).FirstOrDefault();
                
                if (user == null)
                {
                    return 3;
                }
                
                if (!user.ValidatePw(oldPassword))
                {
                    return 1;
                }

                user.SetNewPassword(password);
                mRepository.Save(user);
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

        public bool UpdateUsername(int userId, string username)
        {
            return Update(userId, x => x.Username = username);
        }

        public override User GetElementById(int id)
        {
            return mRepository.GetAllWhere(x => x.Id == id).FirstOrDefault();
        }

        public int UpdateUser(int userId, User user)
        {
            try
            {
                var oldUser = GetElementById(userId);
                if (user == null)
                {
                    return 2;
                }

                user.Password = oldUser.Password;
                mRepository.Save(user);
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
    }
}
