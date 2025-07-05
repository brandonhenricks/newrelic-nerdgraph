using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NewRelic.NerdGraph.Models.Common;

namespace NewRelic.NerdGraph.Helpers
{
    public static class PaginationHelper
    {
        /// <summary>
        /// Asynchronously iterates through all pages of a paginated GraphQL connection, yielding each node.
        /// </summary>
        /// <typeparam name="T">The node/entity type.</typeparam>
        /// <param name="fetchPage">A function that fetches a page given a cursor.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>An async enumerable of nodes.</returns>
        public static async IAsyncEnumerable<T> FetchAllPages<T>(
            Func<string, Task<Connection<T>>> fetchPage,
            int pageSize = 100,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            string cursor = null;
            bool hasNext = true;
            while (hasNext && !cancellationToken.IsCancellationRequested)
            {
                var page = await fetchPage(cursor);
                if (page?.Nodes != null)
                {
                    foreach (var node in page.Nodes)
                        yield return node;
                }
                hasNext = page?.PageInfo?.HasNextPage == true;
                cursor = page?.PageInfo?.EndCursor;
            }
        }
    }
}
