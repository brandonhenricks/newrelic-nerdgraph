using NewRelic.NerdGraph.Models.Common;

namespace NewRelic.NerdGraph.Interfaces;

/// <summary>
/// Provides a builder interface for constructing and executing NerdGraph GraphQL queries.
/// </summary>
public interface IQueryBuilder
{
    /// <summary>
    /// Begins an actor query, allowing access to user, entity, alert, account, and workload queries.
    /// </summary>
    /// <returns>An <see cref="IActorQuery"/> instance for building actor-related queries.</returns>
    IActorQuery Actor();

    /// <summary>
    /// Sets the raw GraphQL query string to be executed.
    /// </summary>
    /// <param name="query">The GraphQL query string.</param>
    /// <returns>The current <see cref="IQueryBuilder"/> instance for chaining.</returns>
    IQueryBuilder WithQuery(string query);

    /// <summary>
    /// Sets the variables to be used with the GraphQL query.
    /// </summary>
    /// <param name="variables">A dictionary of variable names and their values.</param>
    /// <returns>The current <see cref="IQueryBuilder"/> instance for chaining.</returns>
    IQueryBuilder WithVariables(Dictionary<string, object> variables);

    /// <summary>
    /// Executes the constructed GraphQL query asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the expected response data.</typeparam>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="GraphQLResponse{T}"/>.</returns>
    Task<GraphQLResponse<T>> ExecuteAsync<T>(CancellationToken cancellationToken = default);
}
