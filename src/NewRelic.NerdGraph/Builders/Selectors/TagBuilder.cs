using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders.Selectors;

public class TagBuilder : ITagSelection
{
    private readonly QueryBuilder _core;
    public TagBuilder(QueryBuilder core) { _core = core; }
    public ITagSelection SelectKey() { _core.Add("key"); return this; }
    public ITagSelection SelectValues() { _core.Add("values"); return this; }
}
