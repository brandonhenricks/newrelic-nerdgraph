namespace NewRelic.NerdGraph.Models.Alerts
{
    // Models/Alerts/AlertChannel.cs
    public class AlertChannel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
    }
}
