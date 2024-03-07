using Habanero.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Services.EmailSender;
using OnlineShop.Extentions;
using OnlineShop.Infrastructure;
using OnlineShop.ModelBinders;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.GarmentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

//Adding session options
builder.Services.ConfigureApplicationCookie(o =>
{
    o.ExpireTimeSpan = TimeSpan.FromDays(5);
    o.SlidingExpiration = true;
});

//adding application services by extention class
builder.Services.AddApplicationService();



builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews()
    .AddMvcOptions(o =>
    {
       // o.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    });


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
