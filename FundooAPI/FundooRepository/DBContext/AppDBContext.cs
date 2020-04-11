using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.DBContext
{
    public class AppDBContext:IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options)
        {

        }
    }
}
