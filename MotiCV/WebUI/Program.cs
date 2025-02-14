using Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using WebUI.Filters;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews(cfg =>
            {
                cfg.Filters.Add<GlobalExceptionFilter>();
            });

            builder.Host.UseServiceProviderFactory(new IoCFactory());

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            builder.Services.AddDbContext<DbContext>(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"));
            });

            builder.Services.Configure<EmailConfiguration>(cfg => builder.Configuration.GetSection(cfg.GetType().Name).Bind(cfg));
            builder.Services.Configure<CryptoServiceConfiguration>(cfg => builder.Configuration.GetSection(cfg.GetType().Name).Bind(cfg));

            builder.Services.AddHttpContextAccessor();




            var app = builder.Build();
                

            app.UseStaticFiles();



            app.MapControllerRoute(name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
