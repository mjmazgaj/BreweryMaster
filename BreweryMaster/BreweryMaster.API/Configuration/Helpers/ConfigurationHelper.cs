using Serilog;
using Serilog.Core;

namespace BreweryMaster.API.Configuration.Helpers
{
    public static class ConfigurationHelper
    {
        public static Logger GetLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(
                    "logs/errors-.log",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 5,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error
                )
                .WriteTo.File(
                    "logs/info-.log",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 5,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
                )
                .CreateLogger();
        }
    }
}
