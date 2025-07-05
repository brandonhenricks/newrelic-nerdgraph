namespace NewRelic.NerdGraph.Interfaces.Selector;

/// <summary>
/// Represents a selector for a collection, providing methods to select count and entities with specific fields.
/// </summary>
public interface ICollectionSelection
{
    /// <summary>
    /// Selects the count of items in the collection.
    /// </summary>
    /// <returns>
    /// The current <see cref="ICollectionSelection"/> instance for method chaining.
    /// </returns>
    ICollectionSelection SelectCount();

    /// <summary>
    /// Selects entities from the collection using the specified entity selector.
    /// </summary>
    /// <param name="selector">
    /// A function that configures the <see cref="IEntitySelector"/> to specify which fields to select for each entity.
    /// </param>
    /// <returns>
    /// The current <see cref="ICollectionSelection"/> instance for method chaining.
    /// </returns>
    ICollectionSelection SelectEntities(Func<IEntitySelector, IEntitySelector> selector);
}
