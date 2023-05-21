using HW4.Abstract;
using HW4.DataAccess;
using HW4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Repository
{
    public class UserRepository : IUserRepository
    {
        CSVAccess csvAccess = new CSVAccess();

        public bool Create(User user)
        {
            var users = csvAccess.GetAllUsers();
            var sameUser = users.FirstOrDefault(u => u.Mobile == user.Mobile);

            if (sameUser == null)
            {
                user.ID = users.Count() + 1;
                users.Add(user);
                csvAccess.SetAllUsers(users);
                return true;
            }
            else
                return false;
        }

        public bool Delete(string Mobile)
        {
            var users = csvAccess.GetAllUsers();
            var existUser = users.FirstOrDefault(u => u.Mobile == Mobile);

            if (existUser != null)
            {
                var index = users.FindIndex(u => u == existUser);
                users.Remove(existUser);

                for (int i = index; i < users.Count; i++)
                {
                    users[i].ID -= 1;
                }

                csvAccess.SetAllUsers(users);
                return true;
            }
            else
                return false;
        }

        public List<User> GetAllUsers()
        {
            return csvAccess.GetAllUsers();
        }

        public bool Update(string Mobile, User newUser)
        {
            var users = csvAccess.GetAllUsers();
            var existUser = users.FirstOrDefault(u => u.Mobile == Mobile);
            if (existUser != null)
            {
                existUser.Mobile = newUser.Mobile;
                existUser.Name = newUser.Name;
                existUser.BirthDay = newUser.BirthDay;
                return true;
            }
            else
                return false;
        }
    }
}
