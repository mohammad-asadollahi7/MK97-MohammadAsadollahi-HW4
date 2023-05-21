using HW4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Abstract
{
    public interface IUserRepository
    {
        bool Create(User user);

        bool Delete(int ID);

        List<User> GetAllUsers();

        bool Update(int ID, User newUser);

    }
}
