using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFeatureArtifacts(this IServiceCollection services)
    {
        var currentAssembly = Assembly.GetEntryAssembly();
        var assemblies = currentAssembly
                                 .GetReferencedAssemblies()
                                 .Select(Assembly.Load)
                                 .ToList();

        assemblies.Add(currentAssembly);

        assemblies.SelectMany(a => a.GetTypes())
                  .Where(t => t.FullName.Contains(".Features."))
                  .Where(t => !t.IsAbstract && !typeof(ControllerBase).IsAssignableFrom(t))
                  .ToList()
                  .ForEach(t => services.AddTransient(t));

        return services;
    }
}