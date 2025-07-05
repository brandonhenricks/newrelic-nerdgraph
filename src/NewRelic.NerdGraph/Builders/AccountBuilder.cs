using NewRelic.NerdGraph.Interfaces;

namespace NewRelic.NerdGraph.Builders;

public class AccountBuilder : IAccountQuery
{
    private readonly IQueryBuilder _root;
    private readonly QueryBuilder _core;
    public AccountBuilder(IQueryBuilder root, QueryBuilder core) { _root = root; _core = core; }
    public INrqlQuery Nrql(string nrql)
    {
        _core.SelectField($"nrql(query: \"{nrql}\") {{ results }}");
        return new NrqlBuilder(_root, _core);
    }
}
