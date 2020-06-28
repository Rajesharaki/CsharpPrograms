using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Context
{
    public class BookDbContext : IdentityDbContext<IdentityUser>
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        public DbSet<Book> books { get; set; }

        public DbSet<Cart> cart { get; set; }

        public DbSet<WishList> wishLists { get; set; }

        public DbSet<Summary> summaries { get; set; }
    }
}
