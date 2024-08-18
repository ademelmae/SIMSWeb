using SIMSWeb.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

// builder.WebHost.UseUrls("https://localhost:7205", "https://192.168.137.33:7205");

builder.Services.AddControllersWithViews();
var connectionString = configuration.GetConnectionString("DefaultConnection");


var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));


builder.Services.AddDbContext<simsdbContext>(options =>
    options.UseMySql(connectionString, serverVersion));
    
builder.Services.AddSingleton(configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
        );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAllOrigins");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
 app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers(); 
    });

app.Run();
    