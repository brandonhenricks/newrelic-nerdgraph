namespace NewRelic.NerdGraph.Interfaces.Selector;

/// <summary>
/// Provides methods to select specific fields of an alert channel in a query.
/// </summary>
public interface IAlertChannelSelection
{
    /// <summary>
    /// Selects the <c>id</c> field of the alert channel.
    /// </summary>
    /// <returns>The current <see cref="IAlertChannelSelection"/> instance for method chaining.</returns>
    IAlertChannelSelection SelectId();

    /// <summary>
    /// Selects the <c>name</c> field of the alert channel.
    /// </summary>
    /// <returns>The current <see cref="IAlertChannelSelection"/> instance for method chaining.</returns>
    IAlertChannelSelection SelectName();

    /// <summary>
    /// Selects the <c>type</c> field of the alert channel.
    /// </summary>
    /// <returns>The current <see cref="IAlertChannelSelection"/> instance for method chaining.</returns>
    IAlertChannelSelection SelectType();
}
