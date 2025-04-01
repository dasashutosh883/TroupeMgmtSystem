using Event.Api.Extensions.Middlewares;
namespace Event.Api.Extensions;
public static class MiddlewareExtension
{
    public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ValidationMiddleware>();
    }
}
