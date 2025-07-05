using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders.Selectors;

public class UserSelectionBuilder : IUserSelection
{
    private readonly QueryBuilder _core;
    public UserSelectionBuilder(QueryBuilder core) { _core = core; }
    public IUserSelection SelectName() { _core.Add("name"); return this; }
}
