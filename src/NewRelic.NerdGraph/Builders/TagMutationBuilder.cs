using NewRelic.NerdGraph.Interfaces;

namespace NewRelic.NerdGraph.Builders;

// Tagging Mutation Builder
public class TagMutationBuilder : ITagMutation
{
    private readonly IQueryBuilder _root;
    private readonly QueryBuilder _core;

    public TagMutationBuilder(IQueryBuilder root, QueryBuilder core)
    {
        _root = root;
        _core = core;
    }

    public IQueryBuilder Done()
    {
        _core.SelectField("}"); // close taggingAddTagsToEntity
        _core.SelectField("}"); // close actor
        return _root;
    }
}
