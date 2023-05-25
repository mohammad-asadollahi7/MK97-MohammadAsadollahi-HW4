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
        private CSVAccess _csvAccess;
        private List<User> _users;
        public UserRepository(CSVAccess csvAccess)
        {
            _csvAccess = csvAccess;
            _users = _csvAccess.GetAllUsers();
        }

        public bool Create(User user)
        {
            var sameUser = _users.FirstOrDefault(u => u.Mobile == user.Mobile);

            if (sameUser == null)
            {
                user.ID = _users.Count() + 1;
                _users.Add(user);
                _csvAccess.SetAllUsers(_users);
                return true;
            }
            else
                return false;
        }

        public bool Delete(int ID)
        {
            var existUser = _users.FirstOrDefault(u => u.ID == ID);

            if (existUser != null)
            {
                var index = _users.FindIndex(u => u == existUser);
                _users.Remove(existUser);

                for (int i = index; i < _users.Count; i++)
                {
                    _users[i].ID -= 1;
                }

                _csvAccess.SetAllUsers(_users);
                return true;
            }
            else
                return false;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public bool Update(int ID, User updateUser)
        {
            var existUser = _users.FirstOrDefault(u => u.ID == ID);
            if (existUser != null)
            {
                existUser.Mobile = updateUser.Mobile;
                existUser.Name = updateUser.Name;
                existUser.BirthDay = updateUser.BirthDay;
                _csvAccess.SetAllUsers(_users);
                return true;
            }
            else
                return false;
        }
    }
}
