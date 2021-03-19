using Microsoft.AspNetCore.Identity;

namespace JwtExampleConfiguration.Data.UserEntities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
