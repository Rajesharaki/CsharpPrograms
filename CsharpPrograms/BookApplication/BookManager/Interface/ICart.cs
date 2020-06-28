using BookManager.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Interface
{
    public interface ICart
    {
        Task<int> AddCartAsync(Guid bookId, string email);
        List<Book> GetAllCartBooks(string email);
    }
}
