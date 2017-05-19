using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLS.Api.Models;
using BLS.Core.Data;
using BLS.Services;

namespace BLS.Api.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public BookController()
        {
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookService.GetAll();
        }

        public IHttpActionResult GetBookById(int id)
        {
            var books = _bookService.GetById(id);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }
    }
}
