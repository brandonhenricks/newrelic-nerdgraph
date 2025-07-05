using NewRelic.NerdGraph.Interfaces;
using NewRelic.NerdGraph.Models.Common;

namespace NewRelic.NerdGraph.Builders;
public class MutationBuilder : IMutationBuilder
{
    private readonly IQueryBuilder _root;
    private readonly QueryBuilder _core;

    public MutationBuilder(IQueryBuilder root, QueryBuilder core)
    {
        _root = root;
        _core = core;
    }
    public IMutationBuilder UseFragment(string name)
    {
        _core.SelectField($"...{name}");
        return this;
    }

    public ITagMutation TagEntity(string guid, Func<ITagInputBuilder, ITagInputBuilder> tagBuilder)
    {
        _core.SelectField($"tagEntity(guid: \"{guid}\", tags: [");
        tagBuilder(new TagInputBuilder(_core));
        _core.SelectField("]) {");
        return new TagMutationBuilder(this, _core); // Return self to preserve mutation chain
    }

    public IActorQuery Actor()
    {
        _core.SelectField("actor {");
        return new ActorBuilder(this, _core);
    }

    public IQueryBuilder Done()
    {
        _core.SelectField("}");
        return _root;
    }

    public IFragmentBuilder Fragment()
    {
        return new FragmentBuilder(this, _core);
    }

    public IQueryBuilder WithQuery(string query)
    {
        return _core.WithQuery(query);
    }

    public IQueryBuilder WithVariables(Dictionary<string, object> variables)
    {
        return _core.WithVariables(variables);
    }

    public Task<GraphQLResponse<T>> ExecuteAsync<T>(CancellationToken cancellationToken = default)
    {
        return _core.ExecuteAsync<T>(cancellationToken);
    }

}
