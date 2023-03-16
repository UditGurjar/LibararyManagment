
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ApplicationDbContext:DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public  DbSet<Role>Roles { get; set; }
        public  DbSet<User>Users { get; set; }
        public  DbSet<Book>Books { get; set; }
        public DbSet<BookRating>BookRatings { get; set; }
        public DbSet<BookIssue> BookIssues  { get; set; }
        public  DbSet<BookReview>BookReviews { get; set; }
        public  DbSet<BookCategory>BookCategories { get; set; }

    }
}
