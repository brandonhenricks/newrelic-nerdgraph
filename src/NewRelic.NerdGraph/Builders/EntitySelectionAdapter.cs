using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders;

public class EntitySelectionAdapter : IEntitySelector
{
    private readonly QueryBuilder _core;
    public EntitySelectionAdapter(QueryBuilder core) { _core = core; }
    public IEntitySelector SelectGuid() { _core.Add("guid"); return this; }
    public IEntitySelector SelectName() { _core.Add("name"); return this; }
    public IEntitySelector SelectAccountId() { _core.Add("accountId"); return this; }

}
