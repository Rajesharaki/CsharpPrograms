using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Models
{
    public class DataDbContext : DbContext
    {
        /// <summary>
        /// this is the constructor calls the base class constructor
        /// </summary>
        /// <param name="options"></param>
        public DataDbContext(DbContextOptions<DataDbContext> options): base(options)
        {
        }

        /// <summary>
        /// adding the User class object to DbSet which internally creates the table of user
        /// </summary>
        public DbSet<User> users { get; set; }
    }
}
