using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookImage { get; set; }
        public string BookDescription { get; set; }
        public string BookAuthor { get; set; }
        public int TotalBooks { get; set; }
        public DateTime BookExpiryDate { get; set; }
        public int? BookCategoryId { get; set; }
        public  BookCategory BookCategory { get; set; }
      
        public  ICollection<BookReview> BookReviews { get; set; }
        public ICollection<BookRating> BookRatings { get; set; }
    }
}
