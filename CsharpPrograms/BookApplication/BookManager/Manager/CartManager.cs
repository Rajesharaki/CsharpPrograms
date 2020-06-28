using BookManager.Context;
using BookManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Manager
{
    public class CartManager : ICart
    {
        private readonly BookDbContext _context;

        public CartManager(BookDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddCartAsync(Guid bookId, string email)
        {
            var cartModel = new Cart
            {
                BookId = bookId,
                UserName = email
            };
           await  _context.cart.AddAsync(cartModel);
            return await _context.SaveChangesAsync();
        }

        public List<Book> GetAllCartBooks(string email)
        {
            var books = this._context.books.ToList();
            var CartList = this._context.cart.Where(t => t.UserName == email);
            var CartedBooks = books.Where(t => CartList.Any(m => m.BookId == t.BookId));
            return CartedBooks.ToList();
        }
    }
}
