using Data.Access.Data;
using Data.Access.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YogaManagement.Attributes;
using YogaManagement.Common;
using YogaManagement.Infrastructure.Settings;
using YogaManagement.Services;
using YogaManagement.Validator;
using YogaManagement.ViewModel.Auth;

namespace YogaManagement.Infrastructure
{
    public static partial class Startup
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Load Database Setting
            var dbSetting = new DataBaseSetting();
            configuration.GetSection(typeof(DataBaseSetting).Name).Bind(dbSetting, options => options.BindNonPublicProperties = true);

            // Load Web Setting
            var webSetting = new WebSetting();
            configuration.GetSection(typeof(WebSetting).Name).Bind(webSetting, options => options.BindNonPublicProperties = true);

            services.AddSingleton(dbSetting);

            // Add Http Context Accessor
            services.AddHttpContextAccessor();

            // Add Controller With Views
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(LoggingFilterService));
            });

            // Authentication service
            // Cookie scheme
            var authBuilder = services.AddAuthentication(options =>
            {
                options.DefaultScheme = webSetting.CookieAuthScheme;
            });

            authBuilder.AddCookie(webSetting.CookieAuth, options =>
            {
                options.Cookie = new CookieBuilder() { 
                    Name = webSetting.CookieAuth
                };
                options.ExpireTimeSpan = TimeSpan.FromMinutes(webSetting.ExpiredTimeMinutes);
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.LoginPath = webSetting.LoginPath;
                options.LogoutPath = webSetting.LogoutPath;
                options.AccessDeniedPath = webSetting.DeniedPath;
                options.ReturnUrlParameter = "returnUrl";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Const.ADMIN_POLICY, 
                    policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
            });

            // Attributes services
            services.ConfigureAttributeServices();

            // Auto Mapper services
            services.AddAutoMapper(typeof(Program).Assembly);

            // ==== ADD SCOPE EF AND Repository ===========================
            // Config databases setting
            services.AddDbContext<YogaManagementDbContext>(options =>
            {
                options.UseSqlServer(dbSetting.ConnectionString);
            });

            // DI (CRUD)
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add all services instance
            services.AddScoped<IAuthService, AuthService>();

            // Add FluentValidation
            services.ConfigureValidatorServices();
        }

        public static void ConfigureValidatorServices(this IServiceCollection services)
        {
            //services.AddScoped<IValidator<Class>, ClassValidator>();
            //services.AddScoped<IValidator<Product>, ProductValidator>();
            //services.AddScoped<IValidator<Client>, ClientValidator>();
            //services.AddScoped<IValidator<Course>, CourseValidator>();
            //services.AddScoped<IValidator<Shift>, ShiftValidator>();
            services.AddScoped<IValidator<LoginViewModel>, LoginValidator>();
            services.AddScoped<IValidator<RegisterViewModel>, RegisterValidator>();
        }

        public static void ConfigureAttributeServices(this IServiceCollection services)
        {
            services.AddScoped<LoggingFilterService>();
        }
    }
}
