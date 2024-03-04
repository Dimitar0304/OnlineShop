using Microsoft.AspNetCore.Identity.UI.Services;
using OnlineShop.Core.Services.EmailSender;
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
         



            return services;

        }
    }
}
