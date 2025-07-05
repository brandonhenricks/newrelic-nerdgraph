namespace NewRelic.NerdGraph.Interfaces.Selector;

/// <summary>
/// Defines a selector interface for workload status selection operations.
/// </summary>
public interface IWorkloadStatusSelection
{
    /// <summary>
    /// Selects the status value for the workload.
    /// </summary>
    /// <returns>
    /// An <see cref="IWorkloadStatusSelection"/> instance for further selection operations.
    /// </returns>
    IWorkloadStatusSelection SelectStatusValue();
}
