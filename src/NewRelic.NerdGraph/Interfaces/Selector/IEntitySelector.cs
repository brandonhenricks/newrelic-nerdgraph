namespace NewRelic.NerdGraph.Interfaces.Selector;

/// <summary>
/// Defines methods for selecting specific properties of an entity in a query.
/// </summary>
public interface IEntitySelector
{
    /// <summary>
    /// Selects the GUID property of the entity.
    /// </summary>
    /// <returns>
    /// The current <see cref="IEntitySelector"/> instance for method chaining.
    /// </returns>
    IEntitySelector SelectGuid();

    /// <summary>
    /// Selects the Name property of the entity.
    /// </summary>
    /// <returns>
    /// The current <see cref="IEntitySelector"/> instance for method chaining.
    /// </returns>
    IEntitySelector SelectName();

    /// <summary>
    /// Selects the Account ID property of the entity.
    /// </summary>
    /// <returns>
    /// The current <see cref="IEntitySelector"/> instance for method chaining.
    /// </returns>
    IEntitySelector SelectAccountId();
}
