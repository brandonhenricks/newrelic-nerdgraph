
using NewRelic.NerdGraph.Interfaces;

namespace NewRelic.NerdGraph.Builders;

public class WorkloadBuilder : IWorkloadQuery
{
    private readonly IQueryBuilder _root;
    private readonly QueryBuilder _core;
    public WorkloadBuilder(IQueryBuilder root, QueryBuilder core) { _root = root; _core = core; }
    public IQueryBuilder SelectName() { _core.SelectField("name"); return _root; }
    public IQueryBuilder SelectGuid() { _core.SelectField("guid"); return _root; }

    /// <summary>
    /// Adds pagination arguments to the workload query.
    /// </summary>
    public IWorkloadQuery WithPagination(int? first = null, string after = null)
    {
        if (first.HasValue)
            _core.WithArgument("first", first.Value);
        if (!string.IsNullOrEmpty(after))
            _core.WithArgument("after", after);
        return this;
    }
}
