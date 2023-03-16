using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
      
    }
}
