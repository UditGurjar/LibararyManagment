using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<BookReview> BookReviews { get; set; }
        public ICollection<BookRating> BookRatings { get; set; }
    }
}
