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
                name: "Home",
                pattern: "/Error",
                defaults: new { controller = "Home", action = "Error" }
            );

            route.MapControllerRoute(
                name: "Auth",
                pattern: "/Auth",
                defaults: new { controller = "Auth", action = "Index" }
            );

            route.MapControllerRoute(
                name: "Auth",
                pattern: "/Auth/logout",
                defaults: new { controller = "Auth", action = "Logout" }
            );

            route.MapControllerRoute(
                name: "Auth",
                pattern: "/Auth/Register",
                defaults: new { controller = "Auth", action = "Register" }
            );

            route.MapControllerRoute(
                name: "Auth",
                pattern: "/Auth/RegisterEnd",
                defaults: new { controller = "Auth", action = "RegisterEnd" }
            );

            route.MapControllerRoute(
                name: "Class",
                pattern: "/Class",
                defaults: new { controller = "Class", action = "Index"}
            );

            route.MapControllerRoute(
                name: "Class",
                pattern: "/Class/Register",
                defaults: new { controller = "Class", action = "RegisterClassData" }
            );
        }
    }
}
