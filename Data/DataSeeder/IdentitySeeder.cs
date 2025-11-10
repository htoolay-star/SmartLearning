using FirstProjectApp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace FirstProjectApp.Data.DataSeeder
{
    public class IdentitySeeder
    {
        public static async Task SeedSuperAdminAsync
            (UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            #region Create roles
            // Create roles
            string[] roles = { "Superadmin", "Admin", "Teacher", "Student" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            #endregion

            #region Create supperadmin user
            // Create Superadmin user
            string email = "superadmin@smartlearn.com";
            string password = "SuperSecure123!";

            var superadminUser = await userManager.FindByEmailAsync(email);
            if (superadminUser == null)
            {
                superadminUser = new AppUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(superadminUser, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superadminUser, "Superadmin");
                }
            }
            #endregion
        }
    }
}
