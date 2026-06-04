using Microsoft.AspNetCore.Identity;

namespace CineScope.Data
{
    public static class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            string memberRole = "Member";
            string adminRole = "Admin";

            // Ensure roles exist
            if (!await roleManager.RoleExistsAsync(memberRole))
                await roleManager.CreateAsync(new IdentityRole(memberRole));

            if (!await roleManager.RoleExistsAsync(adminRole))
                await roleManager.CreateAsync(new IdentityRole(adminRole));

            // -------------------------
            // CREATE ADMIN USER
            // -------------------------
            var adminEmail = "admin@admin.se";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }

            // -------------------------
            // CREATE MEMBER USERS
            // -------------------------
            for (int i = 1; i <= 5; i++)
            {
                var email = $"user{i}@member.se";

                var user = await userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, "Member123!");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, memberRole);
                    }
                }
            }
        }
    }
}