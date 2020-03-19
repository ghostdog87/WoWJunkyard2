using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<WoWUser> userManager){
            if (!userManager.Users.Any())
            {
                var users = new List<WoWUser>
                {
                    new WoWUser
                    {
                        DisplayName = "Gosho",
                        UserName = "gosho",
                        Email = "gosho@abv.bg"
                    },
                    new WoWUser
                    {
                        DisplayName = "Pesho",
                        UserName = "pesho",
                        Email = "pesho@abv.bg"
                    },
                    new WoWUser
                    {
                        DisplayName = "Sasho",
                        UserName = "sasho",
                        Email = "sasho@abv.bg"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user,"Ghostd0g_87");
                }
            }
        }
    }
}