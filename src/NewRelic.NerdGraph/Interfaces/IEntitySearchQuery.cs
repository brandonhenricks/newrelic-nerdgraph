using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Interfaces;

/// <summary>
/// Provides a builder interface for constructing and executing entity search queries in NerdGraph.
/// </summary>
public interface IEntitySearchQuery
{
    /// <summary>
    /// Specifies the entity selection criteria for the search query.
    /// </summary>
    /// <param name="selector">
    /// A function that configures the <see cref="IEntitySelector"/> to select specific entity fields.
    /// </param>
    /// <returns>
    /// The current <see cref="IEntitySelector"/> instance for further selection configuration.
    /// </returns>
    IEntitySelector SelectEntities(Func<IEntitySelector, IEntitySelector> selector);

    /// <summary>
    /// Completes the entity search query and returns the query builder for further configuration or execution.
    /// </summary>
    /// <returns>
    /// An <see cref="IQueryBuilder"/> instance for building and executing the query.
    /// </returns>
    IQueryBuilder Done();
}
