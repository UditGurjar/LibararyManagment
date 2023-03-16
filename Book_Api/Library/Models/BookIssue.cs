using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookIssue
    {
        public int BookIssueId { get; set; }
        public DateTime BookIssueDate { get; set; }
        public DateTime BookIssueExpiryDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public  BookStatus BookStatus { get; set; }
    }
}
