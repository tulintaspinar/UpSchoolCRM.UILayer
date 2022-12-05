using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UpSchoolCRM.BusinessLayer.DIContainer;
using UpSchoolCRM.DataAccess.Concrete;
using UpSchoolCRM.EntityLayer.Concrete;
using UpSchoolCRM.UILayer.Models;
namespace UpSchoolCRM.UILayer
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
            services.ContainerDependencies();
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddErrorDescriber<CustomeIdentityValidator>().AddEntityFrameworkStores<Context>();

            //type of startup
            services.AddAutoMapper(typeof(Startup));
            services.CustomizeValidator();

            services.AddControllersWithViews().AddFluentValidation();
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().
                             RequireAuthenticatedUser().
                             Build();
                config.Filters.Add(new AuthorizeFilter(policy));//kullanýcý giriþ yapmasýný saðladýk.
                                                                //Aksi ahlde hiçbir sayfaya eriþemez
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index"; //Giriþ ekranýna yönlendirir.
            });
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
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
               );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                   );
            });
        }
    }
}
