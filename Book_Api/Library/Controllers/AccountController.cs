using Library.Repository.IRepository;
using Library.ViewModels;
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
   public class AccountController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        public AccountController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(LoginVM loginVM)
        {
            var token = _loginRepository.Authenticate(loginVM);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
