namespace Clinic.API.Middlewares
{
    public class ShabbatMiddleware
    {
        public readonly RequestDelegate _next;
        public ShabbatMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var shabbat = DateTime.Today.DayOfWeek == DayOfWeek.Saturday;
            if (shabbat)
            {
                context.Response.StatusCode=StatusCodes.Status400BadRequest;
            }
            else
            {
                await _next(context);
            }
        }
    }

    public static class TrackMiddlewareExtensions
    {
        public static IApplicationBuilder UseTrack(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbatMiddleware>();
        }
    }

}
