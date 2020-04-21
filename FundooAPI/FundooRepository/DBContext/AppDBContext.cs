using Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.DBContext
{
    /// <summary>
    /// AppDBContext Implement IdentityDbContext<IdentityUser>
    /// </summary>
    public class AppDBContext:IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// AppDBContext Constructor injection
        /// </summary>
        /// <param name="options">inject DbContextOptions<AppDBContext></param>
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options)
        {

        }
        public DbSet<NotesViewModel> Notes { get; set; }
        public DbSet<LabelViewModel> Labels { get; set; }
    }
}
