using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
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
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return base.Add(user);
        }

        public override List<User> GetAll()
        {
            List<User> users = base.GetAll();
            users.ForEach(x => x.Password = null);

            return users;
        }

        public (bool success, bool isAdmin) Login(string userName, string password)
        {
            try
            {
                User user = mRepository.GetAllWhere(x => x.Username == userName).FirstOrDefault();

                if (user == null)
                {
                    return (false, false);
                }

                bool success = BCrypt.Net.BCrypt.Verify(password, user.Password);
                return (success, user.IsAdmin);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, false);
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

        public bool UpdatePassword(int userId, string password)
        {
            return Update(userId, x => x.Password = BCrypt.Net.BCrypt.HashPassword(password));
        }

        public bool UpdateUsername(int userId, string username)
        {
            return Update(userId, x => x.Username = username);
        }

        protected override bool EqualsId(User obj, int id)
        {
            return obj.Id == id;
        }
    }
}
