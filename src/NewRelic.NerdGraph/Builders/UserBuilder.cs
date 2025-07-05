using NewRelic.NerdGraph.Interfaces;

namespace NewRelic.NerdGraph.Builders;

public class UserBuilder : IUserQuery
{

    private readonly IQueryBuilder _root;
    private readonly QueryBuilder _core;
    public UserBuilder(IQueryBuilder root, QueryBuilder core) { _root = root; _core = core; }
    public IQueryBuilder Done() { _core.Add("}"); return _root; }
}
