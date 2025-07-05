namespace NewRelic.NerdGraph.Interfaces.Selector;

/// <summary>
/// Represents a selector interface for user-related fields in a NerdGraph query.
/// </summary>
public interface IUserSelection
{
    /// <summary>
    /// Selects the <c>Name</c> field for the user in the query.
    /// </summary>
    /// <returns>
    /// An <see cref="IUserSelection"/> instance for further selection chaining.
    /// </returns>
    IUserSelection SelectName();
}
