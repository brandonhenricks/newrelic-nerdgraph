using System;
using System.Collections.Generic;
using System.Text;

namespace NewRelic.NerdGraph.Models.Common;

public class GraphQLError
{
    public string Message { get; set; } = string.Empty;
    public List<string>? Path { get; set; }
    public Dictionary<string, object>? Extensions { get; set; }
}
