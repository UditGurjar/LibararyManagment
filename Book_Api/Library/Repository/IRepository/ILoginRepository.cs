using Library.Models;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository.IRepository
{
   public interface ILoginRepository
    {
       JwtToken Authenticate(LoginVM loginVM);
       
    }
}
