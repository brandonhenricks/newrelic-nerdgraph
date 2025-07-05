namespace NewRelic.NerdGraph.Interfaces;

public interface IMutationBuilder : IQueryBuilder
{
    IFragmentBuilder Fragment();
}
