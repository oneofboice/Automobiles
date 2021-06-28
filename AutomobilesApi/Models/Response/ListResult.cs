using System.Collections.Generic;

namespace AutomobilesApi.Models.Response
{
    public class ListResult<T> : ExecutionResult
    {
        public long PagesCount { get; }
        public long TotalCount { get; }
        public IEnumerable<T> Objects { get; }

        public ListResult(long totalCount, IEnumerable<T> automobiles)
        {
            TotalCount = totalCount;
            Objects = automobiles;
        }

        public ListResult(long totalCount, IEnumerable<T> automobiles, int pageSize)
        {
            TotalCount = totalCount;
            Objects = automobiles;
            PagesCount = totalCount / pageSize;
        }
    }
}
