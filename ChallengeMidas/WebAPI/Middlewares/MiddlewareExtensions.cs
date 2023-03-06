namespace WebAPI.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureMiddlewares(this IApplicationBuilder applicationBuilder) 
        {
            applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
        }
    }
}
