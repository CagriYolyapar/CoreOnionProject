using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.BLL.ServiceExtensions;

namespace WebCoreUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication();
            #region ExtensionServices

            //Extension Metotlarımızı kullanarak servislerimizi inject ediyoruz
            services.AddDbContextService();

            services.AddIdentityService();
            services.AddRepManServices(); 
            #endregion

            #region AddScoped
            //AddScoped ile servis ekleme yönteminde mevcut bir request'te istenilen class birden fazla ise bile tek bir instance alınır


            /* //Asagıdaki Request'e argüman olarak tek bir instance gönderilir
             *
             *      public IActionrResult Deneme(IProductRepository item,IProductRepository item2)
             *      {
             *      
             *      }
             *
             *
             *
             * 
             */
            #endregion



            #region AddSingleton

            /* //Asagıdaki Request'lere AddSingleton kullanıyorsanız sadece tek bir instance(hepsi aynı instance'tir)
           *
           *      public IActionrResult Deneme(IProductRepository item,IProductRepository item2)
           *      {
           *      
           *      }
           *        
           *        public IActionrResult Deneme2(IProductRepository item,IProductRepository item2)
           *        {
           *        
           *        }
           * 
           */



            #endregion


            #region AddTransient

            //Asagıdaki yapılarda her bir yapı icin ayrı instance alınır

            /*
             
                public IActionResult Deneme3(IProductRepository item,IProductRepository item2)
            
            {
            
            
            }
             
             */


            #endregion






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Category}/{action=CategoryList}/{id?}");
            });
        }
    }
}
