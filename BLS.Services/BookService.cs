using System.Collections.Generic;
using System.Threading.Tasks;
using BLS.Core.Data;
using BLS.Core.Infrastructure;
using BLS.Data.Infrastructure;

namespace BLS.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IUnitOfWork unitOfWork)
        {
            _bookRepository = unitOfWork.Repository<Book>();
        }

        public async Task<ICollection<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetById(int id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task<Book> Add(Book books)
        {
            return await _bookRepository.Add(books);
        }

        public async Task<Book> Edit(Book books, int key)
        {
            return await _bookRepository.Edit(books, key);
        }

        public async Task<int> Delete(Book books)
        {
            return await _bookRepository.Delete(books);
        }
    }
}
