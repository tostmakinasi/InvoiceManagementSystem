﻿using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.Repositories;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.UnitOfWorks;
using InvoiceManagement.Repository;
using InvoiceManagement.Repository.Repositories;
using InvoiceManagement.Repository.UnitOfWorks;
using InvoiceManagement.Services.Services;
using Microsoft.AspNetCore.Identity;

namespace InvoiceManagement.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void AddScopedWithExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IHouseTypeService, HouseTypeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
        }
        public static void AddIdentityWithExtension(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromHours(2);
            });

            services.Configure<SecurityStampValidatorOptions>(opt =>//30 dkda bir veritabanı ile client cookie de bulunan securitystamp değerlerini karşılaştıracak
            {
                opt.ValidationInterval = TimeSpan.FromMinutes(30);
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;


            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders(); 
        }

        public static void AddCookieWithExtension(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(opt =>
            {
                var cookieBuilder = new CookieBuilder();
                cookieBuilder.Name = "InvoiceManagementSystemCookie";
                opt.Cookie = cookieBuilder;
                opt.LogoutPath = new PathString("/Members/Logout");
                opt.LoginPath = new PathString("/Home/Signin");
                opt.ExpireTimeSpan = TimeSpan.FromDays(60);
                opt.SlidingExpiration = true;
            });
        }
    }


}
