namespace NewRelic.NerdGraph.Models.Entity;

public class EntityDetails
{
    public string Name { get; set; } = default!;
    public int AccountId { get; set; }
    public string Guid { get; set; } = default!;
    public string Type { get; set; } = default!;
    public bool Reporting { get; set; }
    public List<EntityTag> Tags { get; set; } = [];
    public WorkloadStatus? WorkloadStatus { get; set; }
}
