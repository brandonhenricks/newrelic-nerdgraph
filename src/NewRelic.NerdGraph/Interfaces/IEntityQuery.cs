using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Interfaces;

/// <summary>
/// Provides a builder interface for constructing and customizing entity-related queries in NerdGraph.
/// </summary>
public interface IEntityQuery
{
    /// <summary>
    /// Includes a named fragment in the entity query.
    /// </summary>
    /// <param name="name">The name of the fragment to use.</param>
    /// <returns>The current <see cref="IEntityQuery"/> instance for chaining.</returns>
    IEntityQuery UseFragment(string name);

    /// <summary>
    /// Selects the <c>name</c> field of the entity.
    /// </summary>
    /// <returns>The current <see cref="IEntityQuery"/> instance for chaining.</returns>
    IEntityQuery SelectName();

    /// <summary>
    /// Selects the <c>accountId</c> field of the entity.
    /// </summary>
    /// <returns>The current <see cref="IEntityQuery"/> instance for chaining.</returns>
    IEntityQuery SelectAccountId();

    /// <summary>
    /// Selects the <c>tags</c> field of the entity, allowing further tag selection customization.
    /// </summary>
    /// <param name="selector">A function to configure tag selection.</param>
    /// <returns>The current <see cref="IEntityQuery"/> instance for chaining.</returns>
    IEntityQuery SelectTags(Func<ITagSelection, ITagSelection> selector);

    /// <summary>
    /// Selects a named collection field of the entity, allowing further collection selection customization.
    /// </summary>
    /// <param name="name">The name of the collection to select.</param>
    /// <param name="selector">A function to configure collection selection.</param>
    /// <returns>The current <see cref="IEntityQuery"/> instance for chaining.</returns>
    IEntityQuery SelectCollection(string name, Func<ICollectionSelection, ICollectionSelection> selector);

    /// <summary>
    /// Selects the <c>workloadStatus</c> field of the entity, allowing further workload status selection customization.
    /// </summary>
    /// <param name="selector">A function to configure workload status selection.</param>
    /// <returns>The current <see cref="IEntityQuery"/> instance for chaining.</returns>
    IEntityQuery SelectWorkloadStatus(Func<IWorkloadStatusSelection, IWorkloadStatusSelection> selector);
    
    IEntityQuery WithPagination(int? first = null, string after = null);

    /// <summary>
    /// Completes the entity query and returns the query builder for further configuration or execution.
    /// </summary>
    /// <returns>An <see cref="IQueryBuilder"/> instance for building and executing the query.</returns>
    IQueryBuilder Done();
}
