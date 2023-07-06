using MinimalChatApplication.RequestLoggingMiddleware;

namespace MinimalChatApplication.Extensions
{
    public static class RequestLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomRequestLoggingMiddleware>();
        }
    }
}
