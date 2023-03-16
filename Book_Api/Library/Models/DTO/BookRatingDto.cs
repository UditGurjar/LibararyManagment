using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DTO
{
    public class BookRatingDto
    {
        public int BookRatingId { get; set; }
        public decimal BookNetRating { get; set; }
        public BookRatingType BookRatingType { get; set; }
         public int UserId { get; set; }
         public int BookId { get; set; }
    }
}
