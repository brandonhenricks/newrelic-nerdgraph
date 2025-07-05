using NewRelic.NerdGraph.Interfaces;
using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders;

public class EntitySearchBuilder : IEntitySearchQuery, IEntitySelector
{
    private readonly IQueryBuilder _root;
    private readonly QueryBuilder _core;

    public EntitySearchBuilder(IQueryBuilder root, QueryBuilder core)
    {
        _root = root;
        _core = core;
    }

    public IEntitySelector SelectEntities(Func<IEntitySelector, IEntitySelector> selector)
    {
        selector(this);
        _core.Add("}} }} }");
        return this;
    }

    public IEntitySelector SelectGuid()
    { _core.Add("guid"); return this; }

    public IEntitySelector SelectName()
    { _core.Add("name"); return this; }

    public IEntitySelector SelectAccountId()
    { _core.Add("accountId"); return this; }

    public IQueryBuilder Done()
    { _core.Add("}"); return _root; }
}
