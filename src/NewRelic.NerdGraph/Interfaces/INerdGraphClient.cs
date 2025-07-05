using System;
using System.Collections.Generic;
using System.Text;

namespace NewRelic.NerdGraph.Interfaces;

/// <summary>
/// Defines the contract for a NerdGraph client capable of building and executing GraphQL queries and mutations.
/// </summary>
public interface INerdGraphClient
{
    /// <summary>
    /// Begins building a GraphQL query using the query builder interface.
    /// </summary>
    /// <returns>An <see cref="IQueryBuilder"/> instance for constructing queries.</returns>
    IQueryBuilder Query();

    /// <summary>
    /// Begins building a GraphQL mutation using the mutation builder interface.
    /// </summary>
    /// <returns>An <see cref="IMutationBuilder"/> instance for constructing mutations.</returns>
    IMutationBuilder Mutation();

    /// <summary>
    /// Begins building a manual GraphQL query, allowing for custom query construction.
    /// </summary>
    /// <returns>An <see cref="IQueryBuilder"/> instance for manual query building.</returns>
    IQueryBuilder Manual();
}
