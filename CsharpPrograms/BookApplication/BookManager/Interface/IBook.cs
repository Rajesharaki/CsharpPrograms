using BookManager.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Interface
{
    public interface IBook
    {
        Task<int> AddBooksAsync(Book model);
        List<Book> GetAllBook();
    }
}
