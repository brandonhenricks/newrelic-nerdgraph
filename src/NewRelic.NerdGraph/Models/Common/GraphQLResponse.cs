using System;
using System.Collections.Generic;
using System.Text;

namespace NewRelic.NerdGraph.Models.Common;

public class GraphQLResponse<T>
{
    public T? Data { get; set; }
    public List<GraphQLError>? Errors { get; set; }
}
