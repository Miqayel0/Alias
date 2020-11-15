using Microsoft.AspNetCore.Identity;

namespace Alias.Domain.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsDeleted { get; set; }
    }
}
