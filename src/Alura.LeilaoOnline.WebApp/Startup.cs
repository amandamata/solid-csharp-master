using Alura.LeilaoOnline.WebApp.Dados.EfCore;
using Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces;
using Alura.LeilaoOnline.WebApp.Services;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.LeilaoOnline.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategoriesDao, CategoriesDao>();
            services.AddTransient<IAuctionsDao, AuctionsDao>();
            services.AddTransient<IAdminService, AdminServiceLogicExclusion>();
            services.AddTransient<IProductService, ProductService>();
            services.AddDbContext<AppDbContext>();

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => 
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
