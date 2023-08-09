using Data.Access.Data;
using Data.Models;
using Data.Models.Validator;
using FluentValidation;
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
            services.AddAutoMapper(typeof(Program).Assembly);

            // ==== ADD SCOPE EF AND Repository ===========================
            // Config database setting
            services.AddDbContext<YogaManagementDbContext>(options =>
            {
                options.UseSqlServer(dbSetting.ConnectionString);
            });

            // DI (CRUD)

            // Add all services instance

            // Add FluentValidation
            services.ConfigureValidatorServices();
        }

        public static void ConfigureValidatorServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Class>, ClassValidator>();
            services.AddScoped<IValidator<Product>, ProductValidator>();
            services.AddScoped<IValidator<Client>, ClientValidator>();
            services.AddScoped<IValidator<Course>, CourseValidator>();
            services.AddScoped<IValidator<Shift>, ShiftValidator>();
        }
    }
}
