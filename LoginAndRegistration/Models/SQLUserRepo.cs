using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class SQLUserRepo : IUserRepo
    {
        private UserContext context;

        public SQLUserRepo(UserContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            context.users.Add(user);
            context.SaveChanges();
        }

        public User Delete(int id)
        {
            User user = context.users.Find(id);
            context.users.Remove(user);
            return user;
        }

        public User GetUser(int id)
        {
            return context.users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.users;
        }

        public User Update(User user)
        {
            var usern = context.users.Attach(user);
            usern.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return user;
        }
    }
}
