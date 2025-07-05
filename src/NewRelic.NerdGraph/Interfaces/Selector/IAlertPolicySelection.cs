namespace NewRelic.NerdGraph.Interfaces.Selector;

/// <summary>
/// Provides methods to select specific fields of an alert policy in a query.
/// </summary>
public interface IAlertPolicySelection
{
    /// <summary>
    /// Selects the <c>Id</c> field of the alert policy.
    /// </summary>
    /// <returns>The current <see cref="IAlertPolicySelection"/> instance for method chaining.</returns>
    IAlertPolicySelection SelectId();

    /// <summary>
    /// Selects the <c>Name</c> field of the alert policy.
    /// </summary>
    /// <returns>The current <see cref="IAlertPolicySelection"/> instance for method chaining.</returns>
    IAlertPolicySelection SelectName();

    /// <summary>
    /// Selects the <c>IncidentPreference</c> field of the alert policy.
    /// </summary>
    /// <returns>The current <see cref="IAlertPolicySelection"/> instance for method chaining.</returns>
    IAlertPolicySelection SelectIncidentPreference();
}
