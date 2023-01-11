using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core.Dtos
{
    public class AddBookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public double Rate { get; set; }
        public double Price { get; set; }
    }
}
