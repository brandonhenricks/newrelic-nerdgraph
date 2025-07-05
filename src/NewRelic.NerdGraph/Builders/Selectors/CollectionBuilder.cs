using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders.Selectors;

public class CollectionBuilder : ICollectionSelection
{
    private readonly QueryBuilder _core;
    public CollectionBuilder(QueryBuilder core) { _core = core; }
    public ICollectionSelection SelectCount() { _core.Add("count"); return this; }
    public ICollectionSelection SelectEntities(Func<IEntitySelector, IEntitySelector> selector)
    {
        _core.Add("results { entities {");
        selector(new EntitySelectionAdapter(_core));
        _core.Add("} }");
        return this;
    }
}
