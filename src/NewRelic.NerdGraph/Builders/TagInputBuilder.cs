using NewRelic.NerdGraph.Interfaces;

namespace NewRelic.NerdGraph.Builders;

public class TagInputBuilder : ITagInputBuilder
{
    private readonly QueryBuilder _core;

    public TagInputBuilder(QueryBuilder core)
    {
        _core = core;
    }

    public ITagInputBuilder WithKey(string key)
    {
        _core.SelectField($"key: \"{key}\"");
        return this;
    }

    public ITagInputBuilder WithValues(params string[] values)
    {
        var formatted = string.Join(", ", values.Select(v => $"\"{v}\""));
        _core.SelectField($"values: [{formatted}]");
        return this;
    }
}
