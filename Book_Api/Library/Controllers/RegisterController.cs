using AutoMapper;
using Library.Models;
using Library.Models.DTO;
using Microsoft.AspNetCore.Authorization;
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
   
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RegisterController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Registeruser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<UserDto, User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }
      
    }
}
