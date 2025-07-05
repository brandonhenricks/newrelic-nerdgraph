using NewRelic.NerdGraph.Interfaces;
using NewRelic.NerdGraph.Models.Common;

namespace NewRelic.NerdGraph.Builders;

public class NerdQueryBuilder : IQueryBuilder
{
    private readonly QueryBuilder _core;

    public NerdQueryBuilder(HttpClient httpClient)
    {
        _core = new QueryBuilder(httpClient);
    }

    public IFragmentBuilder Fragment()
    {
        return new FragmentBuilder(this, _core);
    }

    public IActorQuery Actor()
    {
        _core.Add("actor {");
        return new ActorBuilder(this, _core);
    }

    public IQueryBuilder WithQuery(string query) => _core.WithQuery(query);
    public IQueryBuilder WithVariables(Dictionary<string, object> variables) => _core.WithVariables(variables);
    public Task<GraphQLResponse<T>> ExecuteAsync<T>(CancellationToken token = default) => _core.ExecuteAsync<T>(token);
    internal void Add(string part) => _core.Add(part);
}
