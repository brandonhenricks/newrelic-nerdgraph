using NewRelic.NerdGraph.Builders.Selectors;
using NewRelic.NerdGraph.Interfaces;
using NewRelic.NerdGraph.Interfaces.Selector;

namespace NewRelic.NerdGraph.Builders;

public class EntityBuilder : IEntityQuery
{
    private readonly IQueryBuilder _rootEntityBuilder;
    private readonly QueryBuilder _coreEntityBuilder;

    public EntityBuilder(IQueryBuilder rootEntityBuilder, QueryBuilder coreEntityBuilder)
    {
        _rootEntityBuilder = rootEntityBuilder;
        _coreEntityBuilder = coreEntityBuilder;
    }
    /// <summary>
    /// Adds pagination arguments to the entity query.
    /// </summary>
    public IEntityQuery WithPagination(int? first = null, string after = null)
    {
        if (first.HasValue)
            _coreEntityBuilder.WithArgument("first", first.Value);
        if (!string.IsNullOrEmpty(after))
            _coreEntityBuilder.WithArgument("after", after);
        return this;
    }

    public IEntityQuery UseFragment(string name)
    {
        _coreEntityBuilder.SelectField($"...{name}");
        return this;
    }

    public IEntityQuery SelectName()
    {
        _coreEntityBuilder.SelectField("name"); return this;
    }

    public IEntityQuery SelectAccountId()
    {
        _coreEntityBuilder.SelectField("accountId"); return this;
    }

    public IEntityQuery SelectTags(Func<ITagSelection, ITagSelection> selector)
    {
        _coreEntityBuilder.SelectField("tags {");
        selector(new TagBuilder(_coreEntityBuilder));
        _coreEntityBuilder.SelectField("}");
        return this;
    }

    public IEntityQuery SelectCollection(string name, Func<ICollectionSelection, ICollectionSelection> selector)
    {
        _coreEntityBuilder.SelectField($"{name} {{");
        selector(new CollectionBuilder(_coreEntityBuilder));
        _coreEntityBuilder.SelectField("}");
        return this;
    }

    public IEntityQuery SelectWorkloadStatus(Func<IWorkloadStatusSelection, IWorkloadStatusSelection> selector)
    {
        _coreEntityBuilder.SelectField("workloadStatus {");
        selector(new WorkloadStatusBuilder(_coreEntityBuilder));
        _coreEntityBuilder.SelectField("}");
        return this;
    }

    public IQueryBuilder Done()
    { _coreEntityBuilder.SelectField("}"); return _rootEntityBuilder; }
}
