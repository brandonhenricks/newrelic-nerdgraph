using NewRelic.NerdGraph.Models.Entity.Entity;

namespace NewRelic.NerdGraph.Models;

public class Actor
{
    public User? User { get; set; }
    public EntitySearch? EntitySearch { get; set; }
    public Account? Account { get; set; }
}
