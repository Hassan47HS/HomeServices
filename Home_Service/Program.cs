using Home_Service;
using Home_Service.Migrations;
using Home_Service.Models;
using Home_Service.Servicelayer;
using Home_Service.ServiceLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ServicesLayer>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IStripeService, StripeService>();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<HomeServiceDB>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));
builder.Services.AddDefaultIdentity<IdentityUser>(option=>option.SignIn.RequireConfirmedAccount=true).AddRoles<IdentityRole>().AddEntityFrameworkStores<HomeServiceDB>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminRole", policy => policy.RequireRole("Admin"));
});
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSettings"));
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
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
