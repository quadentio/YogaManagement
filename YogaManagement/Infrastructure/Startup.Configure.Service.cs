using Data.Access.Data;
using Data.Access.Repositories;
using Data.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Attributes;
using YogaManagement.Infrastructure.Settings;
using YogaManagement.Validator;

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
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(LoggingFilterService));
            });

            // Authentication service

            // Attributes services
            services.ConfigureAttributeServices();

            // Auto Mapper services
            services.AddAutoMapper(typeof(Program).Assembly);

            // ==== ADD SCOPE EF AND Repository ===========================
            // Config database setting
            services.AddDbContext<YogaManagementDbContext>(options =>
            {
                options.UseSqlServer(dbSetting.ConnectionString);
            });

            // DI (CRUD)
            services.AddScoped<IUnitOfWork, UnitOfWork>();

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
            services.AddScoped<IValidator<User>, UserValidator>();
        }

        public static void ConfigureAttributeServices(this IServiceCollection services)
        {
            services.AddScoped<LoggingFilterService>();
        }
    }
}
