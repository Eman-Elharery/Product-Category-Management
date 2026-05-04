using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ASP.NETCoreD07.Filters
{
    public class PerformanceTimerFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Do something before the action executes.
            Console.WriteLine("Action executing");
            var stopwatch = Stopwatch.StartNew();

            await next();

            // Do something after the action executes.
            stopwatch.Stop();
            Console.WriteLine($"Action executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}