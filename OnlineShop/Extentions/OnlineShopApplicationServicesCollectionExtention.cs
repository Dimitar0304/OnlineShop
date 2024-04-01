using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using OnlineShop.Core.Services.AccessoryService;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Core.Services.EmailSender;
using OnlineShop.Core.Services.GarmentService;
using OnlineShop.Core.Services.ShoeService;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Infrastructure.Data.Models;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.GarmentService;

namespace OnlineShop.Extentions
{
    public static class OnlineShopApplicationServicesCollectionExtention
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            //Add Garment Service
            services.AddScoped<IGarmentService, GarmentService>();

            //Add role service
            //builder.Services.AddTransient<IRoleService, RoleService>();

            //Add email sender service
            services.AddTransient<IEmailSender, EmailSenderService>();

            //Add shoe service
            services.AddScoped<IShoeService, ShoeService>();

            //Add repository
            services.AddScoped<IRepository, Repository>();

            //Add garmentSize service
            services.AddScoped<IGarmentSizeService, GarmentSizeService>();

            //Add shoeSize service
            services.AddScoped<IShoeSizeService, ShoeSizeService>();

            //Add accessory service
            services.AddScoped<IAccessoryService, AccessoryService>();

            services.AddDatabaseDeveloperPageExceptionFilter();
            //Add Cache Data
            services.AddDistributedMemoryCache();
            //Add Session with options
            services.AddSession(options =>
            {
                options.IOTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });

            //Add compression
            services.AddResponseCompression();
           
            return services;

        }
    }
}
