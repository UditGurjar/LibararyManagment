using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookReview
    {
        public int BookReviewId { get; set; }
        public string BookReviewText { get; set; }
        public int BookId { get; set; }
        public  Book Book { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; }
    }
}
