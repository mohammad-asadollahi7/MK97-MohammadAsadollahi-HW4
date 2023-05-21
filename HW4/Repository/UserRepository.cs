using HW4.Abstract;
using HW4.DataAccess;
using HW4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Delete(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public bool Update(User oldUser, User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
