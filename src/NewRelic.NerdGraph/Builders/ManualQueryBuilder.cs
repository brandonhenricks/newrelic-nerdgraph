using System.Net.Http.Json;
using NewRelic.NerdGraph.Interfaces;
using NewRelic.NerdGraph.Models.Common;

namespace NewRelic.NerdGraph.Builders;

public class ManualQueryBuilder : IQueryBuilder
{
    private readonly QueryBuilder _core;

    public ManualQueryBuilder(HttpClient httpClient)
    {
        _core = new QueryBuilder(httpClient);
    }

    /// <summary>
    /// Adds multiple fields to the selection set in a single call.
    /// </summary>
    public ManualQueryBuilder SelectFields(params string[] fields)
    {
        foreach (var field in fields)
            _core.SelectField(field);
        return this;
    }

    /// <summary>
    /// Adds a variable to the query in a type-safe way.
    /// </summary>
    public ManualQueryBuilder WithVariable(string name, object value)
    {
        _core.WithArgument(name, value);
        return this;
    }

    /// <summary>
    /// Example method for adding pagination arguments.
    /// </summary>
    public ManualQueryBuilder WithPagination(int? first = null, string after = null)
    {
        if (first.HasValue)
            _core.WithArgument("first", first.Value);
        if (!string.IsNullOrEmpty(after))
            _core.WithArgument("after", after);
        return this;
    }

    /// <summary>
    /// Validates the built query string for required fields and balanced braces.
    /// </summary>
    public bool ValidateQuery()
    {
        var query = _core.Build();
        int open = 0, close = 0;
        foreach (var c in query)
        {
            if (c == '{') open++;
            if (c == '}') close++;
        }
        return open == close && query.Contains("actor"); // Example: require 'actor' field
    }

    /// <summary>
    /// XML documentation for discoverability.
    /// </summary>
    /// <param name="query">The raw GraphQL query string.</param>
    /// <returns>The builder for chaining.</returns>
    public ManualQueryBuilder WithRawQuery(string query)
    {
        _core.WithQuery(query);
        return this;
    }

    public IFragmentBuilder Fragment()
    {
        return new FragmentBuilder(this, _core);
    }

    public IActorQuery Actor()
    {
        _core.SelectField("actor {");
        return new ActorBuilder(this, _core);
    }

    public IQueryBuilder WithQuery(string query) => _core.WithQuery(query);

    public IQueryBuilder WithVariables(Dictionary<string, object> variables) => _core.WithVariables(variables);

    public Task<GraphQLResponse<T>> ExecuteAsync<T>(CancellationToken cancellationToken = default) => _core.ExecuteAsync<T>(cancellationToken);

}
