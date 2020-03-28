using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class UserContext : IdentityDbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
           
        }
        public DbSet<User> users { get; set; }
    }
}
