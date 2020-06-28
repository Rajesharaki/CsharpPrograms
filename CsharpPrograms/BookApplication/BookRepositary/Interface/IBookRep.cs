using System.Threading.Tasks;

namespace BookRepositary.Interface
{
    public interface IBookRep
    {
        Task<int> AddBooksAsync(global::Comman.Models.BookModels.BookViewModels model);
    }
}
