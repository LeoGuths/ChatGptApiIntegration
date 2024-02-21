using Serilog;

namespace ChatGpt.ApiIntegration.Extensions;

public static class SerilogExtension
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        builder.Logging.ClearProviders();
        builder.Host.UseSerilog(Log.Logger, true);
    }
}