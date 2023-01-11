using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetByID(int id);
        List<T> GetAll();
        T Find(Expression<Func<T, bool>> match, string[] includes = null);

        List<T> FindAll(Expression<Func<T, bool>> match);

        List<T> FindByCategory(Expression<Func<T, bool>> category);

        List<T> FindByRating(Expression<Func<T, bool>> rating);

        
    }
}
