using Data.Access.Data;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Infrastructure.Settings;

namespace YogaManagement.Infrastructure
{
    public static partial class Startup
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Load Database Setting
            var dbSetting = new DataBaseSetting();
            configuration.GetSection(typeof(DataBaseSetting).Name).Bind(dbSetting, options => options.BindNonPublicProperties = true);
            services.AddSingleton(dbSetting);

            // Add Http Context Accessor
            services.AddHttpContextAccessor();

            // Add Controller With Views
            services.AddControllersWithViews();

            // Authentication service

            // Auto Mapper services

            // ==== ADD SCOPE EF AND Repository ===========================
            // Config database setting
            services.AddDbContext<YogaManagementDbContext>(options =>
            {
                options.UseSqlServer(dbSetting.ConnectionString);
            });

            // DI (CRUD)

            // Add all services instance

            // Add FluentValidation
        }
    }
}
