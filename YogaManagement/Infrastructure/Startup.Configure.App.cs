using Serilog;

namespace YogaManagement.Infrastructure
{
    public static partial class Startup
    {
        public static void ConfigureRequestPipeline(this IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetService<IWebHostEnvironment>();

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            // Route config
            app.UseEndpoints(route =>
            {
                RouteConfig.RegisterRoutes(route);
            });
        }
    }
}
