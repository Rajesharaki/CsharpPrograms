using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public interface IUserRepo
    {
        void Add(User user);
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        User Delete(int id);
        User Update(User user);

    }
}
