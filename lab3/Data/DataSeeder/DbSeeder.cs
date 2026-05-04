using ASP.NETCoreD10.Models;
using lab3.Models;
using Microsoft.AspNetCore.Identity;

namespace lab3.Data
{
  
    public static class DbSeeder
    {
        private const string AdminEmail    = "admin@gmail.com";
        private const string AdminPassword = "aaaaaaA1.";

        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new ApplicationRole { Name = role });
            }

            var adminUser = await userManager.FindByEmailAsync(AdminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    FirstName = "Eman",
                    LastName  = "Refaat",
                    Email     = AdminEmail,
                    UserName  = AdminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, AdminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
