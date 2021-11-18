namespace NLayerArchitectureApp.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<ITodoManager, TodoManager>();
        return services;
    }
}