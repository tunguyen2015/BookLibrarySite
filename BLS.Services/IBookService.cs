using System.Collections.Generic;
using BLS.Core.Data;

namespace BLS.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        Book Add(Book books);
        Book Edit(Book books, int key);
        void Delete(Book books);
    }
}
