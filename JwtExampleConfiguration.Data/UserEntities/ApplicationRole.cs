using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace JwtExampleConfiguration.Data.UserEntities
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}
