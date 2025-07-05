using NewRelic.NerdGraph.Builders.Selectors;
using NewRelic.NerdGraph.Interfaces;
using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders;

public class ActorBuilder : IActorQuery
{
    private readonly IQueryBuilder _actorRoot;
    private readonly QueryBuilder _actorCore;

    public ActorBuilder(IQueryBuilder root, QueryBuilder core) { _actorRoot = root; _actorCore = core; }

    public IUserQuery User(Func<IUserSelection, IUserSelection> selector)
    {
        _actorCore.SelectField("user {");
        selector(new UserSelectionBuilder(_actorCore));
        _actorCore.SelectField("}");
        return new UserBuilder(_actorRoot, _actorCore);
    }

    public IEntitySearchQuery EntitySearch(string query)
    {
        _actorCore.SelectField($"entitySearch(query: \"{query}\") {{ results {{ entities {{");
        return new EntitySearchBuilder(_actorRoot, _actorCore);
    }

    public IAccountQuery Account(int accountId)
    {
        _actorCore.SelectField($"account(id: {accountId}) {{");
        return new AccountBuilder(_actorRoot, _actorCore);
    }

    public IWorkloadQuery Workloads(int accountId)
    {
        _actorCore.SelectField($"workloads(accountId: {accountId}) {{");
        return new WorkloadBuilder(_actorRoot, _actorCore);
    }

    public IEntityQuery Entity(string guid)
    {
        _actorCore.SelectField($"entity(guid: \"{guid}\") {{");
        return new EntityBuilder(_actorRoot, _actorCore);
    }
    public IAlertQuery Alerts(int accountId)
    {
        _actorCore.SelectField($"alerts(accountId: {accountId}) {{");
        return new AlertBuilder(_actorRoot, _actorCore);
    }
    public ITagMutation TagEntity(string guid, Func<ITagInputBuilder, ITagInputBuilder> tagBuilder)
    {
        _actorCore.SelectField($"taggingAddTagsToEntity(guid: \"{guid}\", tags: [{{");
        tagBuilder(new TagInputBuilder(_actorCore));
        _actorCore.SelectField("}}]) {");
        _actorCore.SelectField("errors {");
        _actorCore.SelectField("message");
        _actorCore.SelectField("}");
        return new TagMutationBuilder(_actorRoot, _actorCore);
    }
}
