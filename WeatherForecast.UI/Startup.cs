using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Service.Weather;

namespace WeatherForecast.UI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddControllersAsServices();

            services.AddScoped<IWeatherService, WeatherService>();
            services
                .AddMvc()
                // .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddControllersAsServices()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();
            services.AddSession().AddControllersWithViews();
            services.AddResponseCaching();
            services.AddMvcCore().AddRazorPages().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();

        }
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            app.UseDeveloperExceptionPage();

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            
            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Weather}/{action=Index}/{id?}");
            });
        }
    }
}
