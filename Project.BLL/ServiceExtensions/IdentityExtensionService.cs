using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ServiceExtensions
{
    //Identity kullanıyorsanız hazır Identity'lerin(user'lar,sifreler,sifremi unuttum işlemleri icin metotlar) oldugu kütüphane
    public static class IdentityExtensionService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<int>>(x => { x.Password.RequireDigit = false;x.Password.RequireLowercase = false;x.Password.RequireUppercase = false;x.Password.RequireNonAlphanumeric = false;x.Password.RequiredLength = 8; }).AddEntityFrameworkStores<MyContext>();

            return services;
        }
    }
}
