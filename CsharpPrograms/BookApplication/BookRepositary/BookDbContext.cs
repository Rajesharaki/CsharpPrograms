using BookRepositary.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRepositary
{
    public class BookDbContext :IdentityDbContext<IdentityUser>
    {
        public BookDbContext(DbContextOptions <BookDbContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<CartTable> CartTable { get; set; }
        public DbSet<SummaryTable> SummaryTable { get; set; }
        public DbSet<AddressTable> AddressTable { get; set; }
        public DbSet<WishList> WishList { get; set; }
    }
}
