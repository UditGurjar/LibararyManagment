using Library.Models;
using Library.Repository.IRepository;
using Library.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSetting _appSetting;
        public LoginRepository(ApplicationDbContext context, IOptions<AppSetting> appSetting)
        {
            _context = context;
            _appSetting = appSetting.Value;
        }
        public JwtToken Authenticate(LoginVM loginVM)
        {

            var user = _context.Users.Include(c=>c.Role)
                   .Where(x => x.UserEmail == loginVM.UserName && x.UserPassword == loginVM.Password)
                  .FirstOrDefault();
            

            if (user== null)
            {
                return null;
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role,user.Role.RoleName),
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
          
            return new JwtToken { Token = tokenHandler.WriteToken(token) };
        }
    }
}
