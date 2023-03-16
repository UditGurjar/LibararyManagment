using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class JwtToken
    {
        [NotMapped]
        public string Token { get; set; }
        
    }
}
