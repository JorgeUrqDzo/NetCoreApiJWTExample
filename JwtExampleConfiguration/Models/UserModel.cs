using Microsoft.AspNetCore.Identity;

namespace JwtExampleConfiguration.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public UserModel(IdentityUser identityUser)
        {
            Id = identityUser.Id;
            Email = identityUser.Email;
        }
    }
}
