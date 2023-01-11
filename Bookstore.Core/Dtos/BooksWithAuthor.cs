using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core.Dtos
{
    public class BooksWithAuthor
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public double Rate { get; set; }
        public double Price { get; set; }
        public string? AuthorName { get; set; }
    }
}
