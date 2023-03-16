using AutoMapper;
using Library.Models;
using Library.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookIssueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BookIssueController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>

        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> IssueBook([FromBody] BookIssueDto bookIssueDto)
        {
            if (ModelState.IsValid && bookIssueDto != null)
            {
                bookIssueDto.BookIssueDate = DateTime.Now;
                bookIssueDto.BookIssueExpiryDate = DateTime.Now.AddDays(7);
                bookIssueDto.BookStatus = BookStatus.Pending;
                var bookIssue = _mapper.Map<BookIssue>(bookIssueDto);
                _context.BookIssues.Add(bookIssue);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }
        [HttpGet]
        public IActionResult GetBookIssues()
        {
            var bookIssues = _context.BookIssues.ToList();
            return Ok(bookIssues);
        }
        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            if (ModelState.IsValid)
            {
                var user = _context.BookIssues.Include(x => x.Book).FirstOrDefault(x => x.UserId == id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
                //if (user.BookStatus==BookStatus.Approved)
                //{
                //    return Ok(user);
                //}


            }
            return BadRequest();

        }
     }
}
