using System;
using System.Collections.Generic;
using System.Text;

namespace NewRelic.NerdGraph.Models.Alerts
{
    public class AlertPolicy
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string IncidentPreference { get; set; } = default!;
    }
}
