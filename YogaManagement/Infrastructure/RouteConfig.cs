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
        }
    }
}
