using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Extentions;
using OnlineShop.Infrastructure;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.GarmentService;
using OnlineShop.Services.RoleService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//Add Garment Service
builder.Services.AddScoped<IGarmentService, GarmentService>();

//Add role service
//builder.Services.AddTransient<IRoleService, RoleService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();






builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    //use status code page
    app.UseStatusCodePages();

}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//Session option functionality
//app.UseSession()

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//My custom MiddleWare for add admin
//app.UseAddAdmin();



app.MapDefaultControllerRoute();
app.MapRazorPages();



await app.RunAsync();
