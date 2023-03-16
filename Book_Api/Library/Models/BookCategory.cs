using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public string BookCategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
