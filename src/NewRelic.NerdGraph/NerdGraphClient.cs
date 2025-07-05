using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using NewRelic.NerdGraph.Builders;
using NewRelic.NerdGraph.Configurations;
using NewRelic.NerdGraph.Interfaces;

namespace NewRelic.NerdGraph;

public class NerdGraphClient : INerdGraphClient
{
    private readonly HttpClient _httpClient;

    public NerdGraphClient(HttpClient httpClient, IOptions<NerdGraphOptions> options)
    {
        var config = options.Value;

        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(config.Endpoint);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
        _httpClient.Timeout = config.Timeout;
    }

    public IQueryBuilder Query() => new NerdQueryBuilder(_httpClient);
    public IMutationBuilder Mutation() => new NerdMutationBuilder(_httpClient);
    public IQueryBuilder Manual() => new ManualQueryBuilder(_httpClient);
}
