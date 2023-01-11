using Bookstore.Core;
using Bookstore.Core.Dtos;
using Bookstore.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected BookstoreContext? ctx;
        public BaseRepository(BookstoreContext? _ctx)
        {
            ctx= _ctx;
        }
        public List<T> GetAll()
        {
            return ctx.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return ctx.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = ctx.Set<T>();
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.SingleOrDefault(match);
        }

        public List<T> FindAll(Expression<Func<T, bool>> match)
        {
            
            return ctx.Set<T>().Where(match).ToList();
        }

        public List<T> FindByCategory(Expression<Func<T, bool>> category)
        {
            return ctx.Set<T>().Where(category).ToList();
        }

        public List<T> FindByRating(Expression<Func<T, bool>> rating)
        {
            return ctx.Set<T>().Where(rating).ToList();
        }

        //public T Add(BooksWithAuthor bookDTO)
        //{
        //    var book = new Book(); 
        //    var author = new Author();
        //    var store = new Bookstores();
        //    book.Title = bookDTO.Title;
        //    book.Category= bookDTO.Category;
        //    book.Rate = bookDTO.Rate;
        //    book.Price = bookDTO.Price;
        //    ctx.Books.Add(book);
        //    author.Name = bookDTO.AuthorName;
        //    ctx.Authors.Add(author);
        //    store.AuthorID = author.Id;
        //    store.BookID = book.Id;
        //    ctx.Bookstores.Add(store);
        //    ctx.SaveChanges();
        //    return store;

        //}

        
    }
}
