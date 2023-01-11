using Bookstore.Core;
using Bookstore.Core.Repositories;
using Bookstore.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Api.Controllers.AuthorController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBaseRepository<Author> _author;
        private readonly BookstoreContext context;
        protected BookstoreContext? _ctx;

        public AuthorController(IBaseRepository<Author> author, BookstoreContext context)
        {
            _author = author;
            _ctx = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var authors = _author.GetAll();
            return Ok(authors);
        }

        [HttpGet("GetAuthorsWithBooks")]
        public async Task<IActionResult> Get()
        {
            //var authors = await _ctx.Authors.Include(b => b.Bookstores).ThenInclude(a => a.Book.Title && a.Book.Category);
            //return Ok(authors);

            var authors = await _ctx.Authors
            .Select(b => new
            {
                b.Id,
                b.Name,
                b.Discription,
                Books = b.Bookstores.Select(ab => ab.Book.Title),
                totalPrice = b.Bookstores.Select(ab => ab.Book.Price).Sum()
            }).ToListAsync();
            return Ok(authors);
        }

        

        [HttpGet("GetByID")]
        public IActionResult GetByID(int id)
        {
            var authorByID = _author.GetByID(id);
            return Ok(authorByID);
        }

        //[HttpGet("GetByName")]
        //public IActionResult GetByName(string name)
        //{
        //    var authorByName = _author.Find(a => a.Name == name);
        //    return Ok(authorByName);
        //}

        [HttpGet("SearchByName")]
        public IActionResult FindAllWithName(string name)
        {
            var authorIncludesName = _author.FindAll(a => a.Name.Contains(name));
            return Ok(authorIncludesName);
        }

        
    }
}
