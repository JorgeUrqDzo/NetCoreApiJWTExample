using Microsoft.AspNetCore.Identity;

namespace JwtExampleConfiguration.Data.UserEntities
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
