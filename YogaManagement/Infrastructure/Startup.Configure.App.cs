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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Add authen middleware
            app.UseEndpoints(route =>
            {
                RouteConfig.RegisterRoutes(route);
            });
        }
    }
}
