namespace NLayerArchitectureApp.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddSingleton<ITodoRepository, TodoRespository>();
        return services;
    }
}