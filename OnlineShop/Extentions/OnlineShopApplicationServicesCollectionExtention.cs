﻿using Microsoft.AspNetCore.Identity.UI.Services;
using OnlineShop.Core.Services.Contracts;
using OnlineShop.Core.Services.EmailSender;
using OnlineShop.Core.Services.ShoeService;
using OnlineShop.Infrastructure.Common;
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


            return services;

        }
    }
}
