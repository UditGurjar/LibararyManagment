using AutoMapper;
using Library.Models;
using Library.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllBooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AllBooksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<BookDto, Book>(bookDto);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(AddBook), new { id = book.BookId }, book);
        }

        [HttpGet]
        public IActionResult GetBook()
        {
            var getData = _context.Books.ToList().Select(_mapper.Map<Book, BookDto>);
            return Ok(getData);

        }

        [HttpGet("{bookstatus}")]
        public IActionResult Statusbooking()
        {
            var status = _context.BookIssues.Select(x =>BookStatus.Pending).ToList();
            return Ok(status);
        }

        [HttpPut("approveBook/{id}")]
        public async Task<IActionResult> ApproveBook(int id)
        {
            var issueBook = await _context.BookIssues.FindAsync(id);
            if (issueBook == null)
            {
                return NotFound();
            }
            if (issueBook.BookStatus == BookStatus.Pending)
            {
                issueBook.BookStatus = BookStatus.Approved;
                _context.BookIssues.Update(issueBook);
                await _context.SaveChangesAsync();
                return Ok();
            }
            if (issueBook.BookStatus == BookStatus.Pending && issueBook.BookStatus == BookStatus.Approved)
            {
                issueBook.BookStatus = BookStatus.Decline;
                _context.BookIssues.Update(issueBook);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("Declinebook/{id}")]
        public async Task<IActionResult> DeclineBook(int id)
        {
            var issueBook = await _context.BookIssues.FindAsync(id);
            if (issueBook == null)
            {
                return NotFound();
            }
           
            if (issueBook.BookStatus == BookStatus.Pending && issueBook.BookStatus == BookStatus.Approved)
            {
                issueBook.BookStatus = BookStatus.Decline;
                _context.BookIssues.Update(issueBook);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
