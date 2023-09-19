using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneShopASPnet.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PhoneShopASPnetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PhoneShopASPnetContext") ?? throw new InvalidOperationException("Connection string 'PhoneShopASPnetContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(Option =>
    {
        Option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        Option.SlidingExpiration = true;
        Option.AccessDeniedPath = "/Forbidden/"; 
    }); 


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
