using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtExampleConfiguration.Models
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public UserModel User { get; set; }
    }
}
