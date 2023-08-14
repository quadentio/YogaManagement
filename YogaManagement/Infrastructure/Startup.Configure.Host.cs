using Serilog;

namespace YogaManagement.Infrastructure
{
    public static partial class Startup
    {
        public static void ConfigureSeriLog(this ConfigureHostBuilder host, IConfiguration config)
        {
            host.UseSerilog((context, configuration) => {
                configuration.ReadFrom.Configuration(config);
            });
        }
    }
}
