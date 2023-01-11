using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Bookstore.Core;

namespace Bookstore.Core
{
    public class Book
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Title { get; set; }
        [MaxLength(20)]
        public string? Category { get; set; }
        public double Rate { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public ICollection<Bookstores>? Bookstores { get; set; }
    }
}
