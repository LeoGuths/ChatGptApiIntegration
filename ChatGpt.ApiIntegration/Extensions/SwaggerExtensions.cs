using Microsoft.OpenApi.Models;

namespace ChatGpt.ApiIntegration.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwagger(this IServiceCollection services, string appName, string version)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(version, new OpenApiInfo
            {
                Title = appName,
                Version = version
            });
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });
    }
    
    public static void UseSwaggerDoc(this IApplicationBuilder app, string appName, string version)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"/swagger/{version}/swagger.json", appName);
            c.RoutePrefix = "swagger";
        });
    }
}