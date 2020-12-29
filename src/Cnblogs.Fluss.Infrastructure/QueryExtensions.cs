using System;
using System.Linq;

namespace Cnblogs.Fluss.Infrastructure
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            return pageIndex == 1 ? query.Take(pageSize) : query.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }
    }
}