using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Alias.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
        public bool IsDeleted { get; set; }

        #region Private fields

        #endregion Private fields
    }
}