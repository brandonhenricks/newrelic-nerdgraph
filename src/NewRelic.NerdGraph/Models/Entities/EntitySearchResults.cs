namespace NewRelic.NerdGraph.Models.Entity;

public class EntitySearchResults
{
    public List<EntityData>? Entities { get; set; }
    public int TotalCount { get; set; } = 0;
    public List<EntitySearchFacet>? Facets { get; set; }
    public string? Query { get; set; }
    public bool HasMore { get; set; } = false;
    public string? NextCursor { get; set; }
}

public class EntitySearchFacet
{
    public string? Name { get; set; }
    public List<EntitySearchFacetValue>? Values { get; set; }
}

public class EntitySearchFacetValue
{
    public string? Value { get; set; }
    public int Count { get; set; } = 0;
}
