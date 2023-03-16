using Library.Models;
using Library.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository.IRepository
{
   public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> AddBook(BookDto bookDto);
        
    }
}
