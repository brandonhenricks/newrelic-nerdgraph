using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewRelic.NerdGraph.Interfaces;
using NewRelic.NerdGraph.Models.Common;

namespace NewRelic.NerdGraph.Builders;

public class QueryBuilder : BaseBuilder<QueryBuilder>
{
    private string? _rawQuery;
    private Dictionary<string, object>? _variables;
    private readonly HttpClient _httpClient;
    private QueryBuilderAdapter? _adapter;

    public QueryBuilder(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void Add(string part)
    {
        SelectField(part);
    }

    public IFragmentBuilder UseFragment(string name)
    {
        SelectField($"...{name}");
        return new QueryBuilderAdapter(this).UseFragment(name);
    }

    public IQueryBuilder WithQuery(string query)
    {
        _rawQuery = query;
        return _adapter ??= new QueryBuilderAdapter(this);
    }

    public IQueryBuilder WithVariables(Dictionary<string, object> variables)
    {
        _variables = variables;
        return _adapter ??= new QueryBuilderAdapter(this);
    }

    public async Task<GraphQLResponse<T>> ExecuteAsync<T>(CancellationToken cancellationToken = default)
    {
        string queryText = _rawQuery ?? Build();

        var requestBody = new
        {
            query = queryText,
            variables = _variables
        };

        var content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync("", content, cancellationToken);
        response.EnsureSuccessStatusCode();

        // .NET Standard 2.0 does not support ReadAsStreamAsync(CancellationToken)
        var stream = await response.Content.ReadAsStreamAsync();

        var result = await JsonSerializer.DeserializeAsync<GraphQLResponse<T>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        }, cancellationToken);

        return result ?? throw new InvalidOperationException("GraphQL response could not be deserialized.");
    }

    private class QueryBuilderAdapter : IQueryBuilder
    {
        private readonly QueryBuilder _builder;

        public QueryBuilderAdapter(QueryBuilder builder)
        {
            _builder = builder;
        }

        public IFragmentBuilder UseFragment(string name) => _builder.UseFragment(name);

        public IActorQuery Actor()
        {
            _builder.Add("actor {");
            return new ActorBuilder(this, _builder);
        }

        public IQueryBuilder WithQuery(string query) => _builder.WithQuery(query);

        public IQueryBuilder WithVariables(Dictionary<string, object> variables) => _builder.WithVariables(variables);

        public Task<GraphQLResponse<T>> ExecuteAsync<T>(CancellationToken cancellationToken = default) => _builder.ExecuteAsync<T>(cancellationToken);
    }
}
