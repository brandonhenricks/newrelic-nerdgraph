using System;
using System.Collections.Generic;
using System.Text;

namespace NewRelic.NerdGraph.Models.Common;

public class GraphQLRequest
{
    public string Query { get; set; } = string.Empty;
    public Dictionary<string, object>? Variables { get; set; }
        = new();
}
