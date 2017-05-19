using System.Collections.Generic;
using BLS.Core.Data;
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

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public Book Add(Book books)
        {
            return _bookRepository.Add(books);
        }

        public Book Edit(Book books, int key)
        {
            return _bookRepository.Edit(books, key);
        }

        public void Delete(Book books)
        {
            _bookRepository.Delete(books);
        }
    }
}
