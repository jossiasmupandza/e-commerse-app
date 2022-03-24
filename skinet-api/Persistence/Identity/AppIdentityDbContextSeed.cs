using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "bob@test.com",
                    UserName = "bob@test.com",
                    Address = new Address
                    {
                        FirstName = "Bob",
                        LastName = "Joe",
                        Street = "Av. Acordos de Lusaka",
                        City = "Maputo",
                        State = "Kamaxaquene",
                        ZipCode = "423423"
                    }
                };

                Console.Write("seed");

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}