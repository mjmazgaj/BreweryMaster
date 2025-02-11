using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace BreweryMaster.API.Configuration.Helpers
{
    public static class MiddlewareProvider
    {
        public static void UseExceptionHandlerWithOptions(this WebApplication app)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                    context.Response.StatusCode = exception switch
                    {
                        ArgumentNullException => StatusCodes.Status400BadRequest,
                        ArgumentOutOfRangeException => StatusCodes.Status400BadRequest,
                        ArgumentException => StatusCodes.Status400BadRequest,
                        UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                        NotSupportedException => StatusCodes.Status405MethodNotAllowed,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        error = exception?.Message
                    }));
                });
            });
        }
    }
}
