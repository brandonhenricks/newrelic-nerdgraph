namespace NewRelic.NerdGraph.Interfaces.Selector;

/// <summary>
/// Represents a selector for tag-based queries, allowing selection of tag keys and values.
/// </summary>
public interface ITagSelection
{
    /// <summary>
    /// Selects the key of the tag.
    /// </summary>
    /// <returns>
    /// An <see cref="ITagSelection"/> instance for further selection.
    /// </returns>
    ITagSelection SelectKey();

    /// <summary>
    /// Selects the values associated with the tag key.
    /// </summary>
    /// <returns>
    /// An <see cref="ITagSelection"/> instance for further selection.
    /// </returns>
    ITagSelection SelectValues();
}
