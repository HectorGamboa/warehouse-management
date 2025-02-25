namespace WH.Api.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder builder1)
        {
            return builder1.UseMiddleware<ValidationMiddleware>();
        }
    }
}
