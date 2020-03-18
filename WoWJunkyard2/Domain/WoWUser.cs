using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class WoWUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
