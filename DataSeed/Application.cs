using Microsoft.AspNetCore.Identity;
using PrintManager.DbContexts;

namespace PrintManager.DataSeed
{
    public static class Application
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
