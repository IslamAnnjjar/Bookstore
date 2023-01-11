using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public class Bookstores
    {
        public int ID { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book? Book { get; set; }
        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public virtual Author? Author { get; set; }
    }
}
