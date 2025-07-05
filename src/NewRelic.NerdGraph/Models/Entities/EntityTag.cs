namespace NewRelic.NerdGraph.Models.Entity;

public class EntityTag
{
    public string Key { get; set; } = default!;
    public List<string> Values { get; set; } = new();
}
