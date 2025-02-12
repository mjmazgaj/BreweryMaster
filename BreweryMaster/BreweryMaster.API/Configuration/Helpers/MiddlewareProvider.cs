using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
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

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature?.Error;

                    if (exception != null)
                    {
                        Serilog.Log.Error(exception, "An exception occurred: {ErrorMessage}", exception.Message);
                    }
                    else
                    {
                        Serilog.Log.Error("An unknown error occurred in the application.");
                    }

                    context.Response.StatusCode = exception switch
                    {
                        ArgumentNullException => StatusCodes.Status400BadRequest,
                        ArgumentOutOfRangeException => StatusCodes.Status400BadRequest,
                        ArgumentException => StatusCodes.Status400BadRequest,
                        UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                        NotSupportedException => StatusCodes.Status405MethodNotAllowed,
                        DbUpdateConcurrencyException => StatusCodes.Status503ServiceUnavailable,
                        DbUpdateException => StatusCodes.Status503ServiceUnavailable,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        error = exception?.Message ?? "An unknown error occurred.",
                    }));
                });
            });
        }
    }
}
