using Microsoft.AspNetCore.Identity;

namespace JwtExampleConfiguration.Data.UserEntities
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
