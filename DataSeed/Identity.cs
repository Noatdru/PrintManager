using Microsoft.AspNetCore.Identity;

namespace PrintManager.DataSeed
{
    public static class Identity
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>)) as UserManager<IdentityUser>;
                IdentityUser user = await userManager.FindByIdAsync(adminUser);
                if (user == null)
                {
                    user = new IdentityUser(adminUser);
                    await userManager.CreateAsync(user, adminPassword);
                }
            }
        }
    }
}
