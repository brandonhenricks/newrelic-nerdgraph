namespace NewRelic.NerdGraph.Interfaces;

public interface ITagInputBuilder
{
    ITagInputBuilder WithKey(string key);
    ITagInputBuilder WithValues(params string[] values);
}
