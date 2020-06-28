using BookManager.Context;
using BookManager.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace BookManager.Manager
{
    public class BookManagers : IBook
    {
        private readonly BookDbContext _context;

        public BookManagers(BookDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddBooksAsync(Book model)
        {
            await _context.books.AddAsync(model);
            return await _context.SaveChangesAsync();
        }

        public List<Book> GetAllBook()
        {
            return this._context.books.ToList();
        }
    }
}
