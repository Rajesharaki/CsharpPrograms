using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class UserRepo : IUserRepo
    {
        private List<User> users;

        public UserRepo()
        {
            this.users = new List<User>()
            {
                new User(){ID=1,Name="ashok",Email="Ashok@gmail.com",},
                new User(){ID=2,Name="Pavan",Email="Pavan@gmail.com",},
                new User(){ID=3,Name="Shivaraj",Email="Shivaraj@gmail.com",}
            };
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public User Delete(int id)
        {
            var user = users.FirstOrDefault(o => o.ID == id);
            users.Remove(user);
            return user;
        }

        public User GetUser(int id)
        {
            var user = this.users.FirstOrDefault(o => o.ID == id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return this.users;
        }

        public User Update(User user)
        {
            return user;
        }
    }
}
