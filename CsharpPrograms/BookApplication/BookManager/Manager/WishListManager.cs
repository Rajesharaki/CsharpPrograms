using BookManager.Context;
using BookManager.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Manager
{
    public class WishListManager:IWishList
    {
        private readonly BookDbContext _context;

        public WishListManager(BookDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCartAsync(Guid bookId, string email)
        {
            await this._context.wishLists.AddAsync(new WishList { BookId=bookId, UserName = email });
            return await this._context.SaveChangesAsync();
        }

        public List<Book> GetAllCartBooks(string email)
        {
            var Allbooks = this._context.books.ToList();
            var WishList = this._context.wishLists.Where(t => t.UserName == email);
            var books = Allbooks.Where(t => WishList.Any(u => u.BookId == t.BookId));
            return books.ToList();
        }

        [HttpPost]
        [Route("OrdrerSummary")]
        public async Task<int> OrdrerSummaryAsync(string email, Guid bookID, Guid addressID)
        {
            var summaryModel = new Summary { AccountUserName = email, AddressID = addressID, BookID = bookID };
            await this._context.summaries.AddAsync(summaryModel);
            return await this._context.SaveChangesAsync();
        }

    }
}
