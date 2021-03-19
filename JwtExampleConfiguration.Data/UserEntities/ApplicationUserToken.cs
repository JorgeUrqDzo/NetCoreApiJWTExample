using Microsoft.AspNetCore.Identity;

namespace JwtExampleConfiguration.Data.UserEntities
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
