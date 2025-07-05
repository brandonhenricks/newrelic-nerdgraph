using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Interfaces;

/// <summary>
/// Provides a builder interface for constructing and executing alert-related NerdGraph GraphQL queries.
/// </summary>
public interface IAlertQuery
{
    /// <summary>
    /// Begins a policy selection query, allowing selection of alert policy-related fields.
    /// </summary>
    /// <param name="selector">A function to configure the alert policy selection.</param>
    /// <returns>The current <see cref="IAlertQuery"/> instance for chaining.</returns>
    IAlertQuery Policies(Func<IAlertPolicySelection, IAlertPolicySelection> selector);

    /// <summary>
    /// Begins a channel selection query, allowing selection of alert channel-related fields.
    /// </summary>
    /// <param name="selector">A function to configure the alert channel selection.</param>
    /// <returns>The current <see cref="IAlertQuery"/> instance for chaining.</returns>
    IAlertQuery Channels(Func<IAlertChannelSelection, IAlertChannelSelection> selector);
    IAlertQuery WithPagination(int? first = null, string after = null);

    /// <summary>
    /// Completes the alert query and returns the query builder for further configuration or execution.
    /// </summary>
    /// <returns>An <see cref="IQueryBuilder"/> instance for building and executing the query.</returns>
    IQueryBuilder Done();
}
