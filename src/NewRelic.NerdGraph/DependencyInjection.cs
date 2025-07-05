using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NewRelic.NerdGraph.Configurations;
using NewRelic.NerdGraph.Interfaces;

namespace NewRelic.NerdGraph;

/// <summary>
/// Provides extension methods for registering the NerdGraph client and its configuration with the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers the <see cref="INerdGraphClient"/> and its configuration using the specified <see cref="IConfiguration"/> instance.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the client to.</param>
    /// <param name="config">The application configuration containing the NerdGraph section.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddNerdGraphClient(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<NerdGraphOptions>(config.GetSection("NerdGraph"));

        services.AddHttpClient<INerdGraphClient, NerdGraphClient>((sp, client) =>
        {
            var opts = sp.GetRequiredService<IOptions<NerdGraphOptions>>().Value;
            client.BaseAddress = new Uri(opts.Endpoint);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", opts.ApiKey);
            client.Timeout = opts.Timeout;
        });

        return services;
    }

    /// <summary>
    /// Registers the <see cref="INerdGraphClient"/> and its configuration using the specified configuration delegate.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the client to.</param>
    /// <param name="configure">An action to configure the <see cref="NerdGraphOptions"/>.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddNerdGraphClient(this IServiceCollection services, Action<NerdGraphOptions> configure)
    {
        services.Configure(configure);
        services.AddHttpClient<INerdGraphClient, NerdGraphClient>((sp, client) =>
        {
            var opts = sp.GetRequiredService<IOptions<NerdGraphOptions>>().Value;
            client.BaseAddress = new Uri(opts.Endpoint);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", opts.ApiKey);
            client.Timeout = opts.Timeout;
        });
        return services;
    }
}
