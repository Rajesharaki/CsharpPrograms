using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginAndRegistration.Models
{
    public class AppDBContext:IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option):base(option)
        {

        }
        public DbSet<IdentityUser> Users { get;set; }
    }
}
