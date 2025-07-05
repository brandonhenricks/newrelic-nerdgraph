using System.Collections.Generic;

namespace NewRelic.NerdGraph.Models.Common
{
    /// <summary>
    /// Represents the standard GraphQL PageInfo object for pagination.
    /// </summary>
    public class PageInfo
    {
        public string EndCursor { get; set; }
        public bool HasNextPage { get; set; }
    }

    /// <summary>
    /// Represents a paginated connection of nodes (entities) with page info.
    /// </summary>
    public class Connection<T>
    {
        public List<T> Nodes { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
