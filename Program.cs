using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrintManager.DbContexts;
using PrintManager.Interfaces;
using PrintManager.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
var services = builder.Services;
services.AddMvc().AddSessionStateTempDataProvider();
services.AddSession();
services.AddMemoryCache();
services.AddControllersWithViews();
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Application")));
services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Identity")));
services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();
services.AddScoped<IPrinterRepository, PrinterRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

PrintManager.DataSeed.Identity.EnsurePopulated(app);

app.Run();
