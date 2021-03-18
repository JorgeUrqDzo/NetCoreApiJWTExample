using Microsoft.AspNetCore.Identity;

namespace JwtExampleConfiguration.Models
{
    public class RegisterResponseModel
    {
        public IdentityResult IdentityResult { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
