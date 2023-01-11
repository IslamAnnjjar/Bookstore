using Bookstore.Core;
using Bookstore.Core.Dtos;
using Bookstore.Core.Repositories;
using Bookstore.EF;
using Bookstore.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bookstore.Api.Controllers.BookController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseRepository<Book> _book;
        private readonly IBaseRepository<Bookstores> _bookstore;
        protected BookstoreContext? _ctx;

        public BookController(IBaseRepository<Book> book, IBaseRepository<Bookstores> bookstore, BookstoreContext context)
        {
            _book = book;
            _bookstore = bookstore;
            _ctx = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var books = _book.GetAll();
            return Ok(books);
        }

        [HttpGet("GetBooksWithAuthors")]
        public async Task<IActionResult> Get()
        {
            //var books = await _ctx.Books.Include(b => b.Bookstores).ThenInclude(a => a.Author).ToListAsync();

            var books = await _ctx.Books
            .Select(b => new {
                b.Id,
                b.Title,
                b.Rate,
                b.Category,
                b.Price,
                Authors = b.Bookstores.Select(ab => ab.Author.Name)
            }).ToListAsync();
            return Ok(books);
        }

        [HttpGet("GetByID")]
        public IActionResult GetById(int id)
        {
            var bookByID = _book.GetByID(id);
            return Ok(bookByID);
        }

        //[HttpGet("GetByAuthorName")]
        //public IActionResult GetByName(int authorID)
        //{
        //    Bookstores bookstores = new Bookstores();

        //    var booksWithAuthorID = _bookstore.Find(b => b.AuthorID == authorID);
        //    var bookByID = _book.Find(b => b.Id == booksWithAuthorID)
        //    return Ok(bookByName); 
        //}

        [HttpGet("GetByCategory")]
        public IActionResult GetByCategory(string categoryName)
        {
            var bookByCategory = _book.FindByCategory(b => b.Category.Contains(categoryName));
            if (bookByCategory == null)
                return NotFound();
            else
                return Ok(bookByCategory);
        }

        [HttpGet("GetByRating")]
        public IActionResult GetByRating(int rating)
        {
            var bookByRating = _book.FindByRating(b => b.Rate <= rating);
            return Ok(bookByRating);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                var book = new Book();
                book.Title = bookDTO.Title;
                book.Category = bookDTO.Category;
                book.Rate = bookDTO.Rate;
                book.Price = bookDTO.Price;
                _ctx.Books.Add(book);
                _ctx.SaveChanges();
                return Ok(book);
            }
            return BadRequest(ModelState);
        }

        

    }
}
