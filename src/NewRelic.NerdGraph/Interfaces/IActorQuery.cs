using System;
using System.Collections.Generic;
using System.Text;
using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Interfaces;

/// <summary>
/// Provides a builder interface for constructing and executing actor-related NerdGraph GraphQL queries.
/// </summary>
public interface IActorQuery
{
    /// <summary>
    /// Begins a user query, allowing selection of user-related fields.
    /// </summary>
    /// <param name="selector">A function to configure the user selection.</param>
    /// <returns>An <see cref="IUserQuery"/> instance for building the user query.</returns>
    IUserQuery User(Func<IUserSelection, IUserSelection> selector);

    /// <summary>
    /// Begins an entity search query using the specified search string.
    /// </summary>
    /// <param name="query">The search query string.</param>
    /// <returns>An <see cref="IEntitySearchQuery"/> instance for building the entity search query.</returns>
    IEntitySearchQuery EntitySearch(string query);

    /// <summary>
    /// Begins an alert query for the specified account.
    /// </summary>
    /// <param name="accountId">The account ID for which to query alerts.</param>
    /// <returns>An <see cref="IAlertQuery"/> instance for building the alert query.</returns>
    IAlertQuery Alerts(int accountId);

    /// <summary>
    /// Begins an account query for the specified account.
    /// </summary>
    /// <param name="accountId">The account ID for which to query account data.</param>
    /// <returns>An <see cref="IAccountQuery"/> instance for building the account query.</returns>
    IAccountQuery Account(int accountId);

    /// <summary>
    /// Begins a workload query for the specified account.
    /// </summary>
    /// <param name="accountId">The account ID for which to query workloads.</param>
    /// <returns>An <see cref="IWorkloadQuery"/> instance for building the workload query.</returns>
    IWorkloadQuery Workloads(int accountId);

    /// <summary>
    /// Begins an entity query for the specified entity GUID.
    /// </summary>
    /// <param name="guid">The GUID of the entity to query.</param>
    /// <returns>An <see cref="IEntityQuery"/> instance for building the entity query.</returns>
    IEntityQuery Entity(string guid);

    /// <summary>
    /// Begins a tag mutation for the specified entity GUID, allowing tags to be set or updated.
    /// </summary>
    /// <param name="guid">The GUID of the entity to tag.</param>
    /// <param name="tagBuilder">A function to configure the tag input.</param>
    /// <returns>An <see cref="ITagMutation"/> instance for building the tag mutation.</returns>
    ITagMutation TagEntity(string guid, Func<ITagInputBuilder, ITagInputBuilder> tagBuilder);
}
