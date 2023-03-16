using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DTO
{
    public class BookIssueDto
    {
        public int BookIssueId { get; set; }
        public DateTime BookIssueDate { get; set; }
        public DateTime BookIssueExpiryDate { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public BookStatus BookStatus { get; set; }
    }
}
