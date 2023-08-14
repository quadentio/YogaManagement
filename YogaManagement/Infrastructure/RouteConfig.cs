using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace YogaManagement.Infrastructure
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(IEndpointRouteBuilder route)
        {
            route.MapControllerRoute(
                name: "Home",
                pattern: "/",
                defaults: new { controller = "Home", action = "Index" }
            );

            route.MapControllerRoute(
                name: "Home",
                pattern: "/Privacy",
                defaults: new { controller = "Home", action = "Privacy" }
            );

            route.MapControllerRoute(
                name: "Auth",
                pattern: "/Auth",
                defaults: new { controller = "Auth", action = "Index" }
            );

            route.MapControllerRoute(
                name: "Auth",
                pattern: "/Auth/login",
                defaults: new { controller = "Auth", action = "Login" }
            );

            route.MapControllerRoute(
                name: "Auth",
                pattern: "/Auth/logout",
                defaults: new { controller = "Auth", action = "Logout" }
            );
        }
    }
}
