using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLS.Core.Data;

namespace BLS.Services
{
    public interface IBookService
    {
        Task<ICollection<Book>> GetAll();
        Task<Book> GetById(object id);
        Task<Book> Add(Book books);
        Task<Book> Edit(Book books, int key);
        Task<int> Delete(Book books);
    }
}
