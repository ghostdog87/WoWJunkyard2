using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class WoWUser : IdentityUser
    {
        public WoWUser()
        {
           Posts = new List<Post>();
        }
        public string DisplayName { get; set; }

        public List<Post> Posts { get; set; }
    }
}
