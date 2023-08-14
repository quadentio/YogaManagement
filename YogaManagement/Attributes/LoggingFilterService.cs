using Microsoft.AspNetCore.Mvc.Filters;

namespace YogaManagement.Attributes
{
    public class LoggingFilterService : IActionFilter
    {
        private readonly ILogger _logger;
        public LoggingFilterService(ILogger<LoggingFilterService> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(
                "Exec{@ControllerName}Controller-{@ActionName}Action, @{DateTimeUTC}",
                context.ActionDescriptor.RouteValues["controller"],
                context.ActionDescriptor.RouteValues["action"],
                DateTime.UtcNow
                );
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation(
                "Executed: {@ControllerName}Controller-{@ActionName}Action, @{DateTimeUTC}",
                context.ActionDescriptor.RouteValues["controller"],
                context.ActionDescriptor.RouteValues["action"],
                DateTime.UtcNow
                );
        }
    }
}
