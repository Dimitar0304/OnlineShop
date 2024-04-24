using OnlineShop.Core.Contracts;
using OnlineShop.Core.Services.AccessoryService;
using OnlineShop.Core.Services.BrandService;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Core.Services.GarmentService;
using OnlineShop.Core.Services.ShoeService;
using OnlineShop.Infrastructure.Common;
using OnlineShop.Services.Contracts;

namespace OnlineShop.Extentions
{
    public static class OnlineShopApplicationServicesCollectionExtention
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            //Add Garment Service
            services.AddScoped<IGarmentService, GarmentService>();

           


            //Add HttpContext
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            

            //Add shoe service
            services.AddScoped<IShoeService, ShoeService>();

            //Add repository
            services.AddScoped<IRepository, Repository>();

           

            //Add accessory service
            services.AddScoped<IAccessoryService, AccessoryService>();

           

            //Add Brand service
            services.AddScoped<IBrandService,BrandService>();

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
