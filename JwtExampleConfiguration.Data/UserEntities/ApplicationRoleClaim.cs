using Microsoft.AspNetCore.Identity;

namespace JwtExampleConfiguration.Data.UserEntities
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
