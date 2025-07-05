using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders.Selectors;

public class WorkloadStatusBuilder : IWorkloadStatusSelection
{
    private readonly QueryBuilder _core;
    public WorkloadStatusBuilder(QueryBuilder core) { _core = core; }
    public IWorkloadStatusSelection SelectStatusValue() { _core.Add("statusValue"); return this; }
}
