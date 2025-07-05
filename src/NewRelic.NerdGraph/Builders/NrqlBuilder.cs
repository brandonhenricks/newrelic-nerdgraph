using NewRelic.NerdGraph.Interfaces;

namespace NewRelic.NerdGraph.Builders;

public class NrqlBuilder : INrqlQuery
{
    private readonly IQueryBuilder _root;
    private readonly QueryBuilder _core;

    public NrqlBuilder(IQueryBuilder root, QueryBuilder core)
    { _root = root; _core = core; }

    public IQueryBuilder Done()
    { 
        _core.SelectField("}"); return _root; 
    }
}
