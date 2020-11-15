using MediatR;
using System.Collections.Generic;

namespace Alias.Application.Roles.Commands.AddClaimToRole
{
    public class AddClaimToRoleCommand : IRequest<bool>
    {
        public string RoleId { get; set; }
        public List<string> Claims { get; set; }

    }

    public class ClaimDto
    {
        public string Type { get; set; }
        public List<string> Values { get; set; }
    }
}
