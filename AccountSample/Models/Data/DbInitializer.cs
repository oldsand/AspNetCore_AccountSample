using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountSample.Models.Data
{
    public class DbInitializer
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "P@ssw0rd";

        private UserManager<IdentityUser> userManager;

        public static async Task Initialize(UserManager<IdentityUser> userMgr)
        {
            IdentityUser user = await userMgr.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userMgr.CreateAsync(user, adminPassword);
            }
        }
    }
}
