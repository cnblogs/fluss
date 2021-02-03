using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cnblogs.Fluss.Infrastructure
{
    /// <summary>
    /// Some extensions methods to simplify LINQ-SQL query.
    /// </summary>
    public static class QueryExtensions
    {
        /// <summary>
        /// Paging and get a specific page in query result.
        /// </summary>
        /// <param name="query">source <see cref="IQueryable{T}"/>.</param>
        /// <param name="pageIndex">The specific page's index needs to get in query result.</param>
        /// <param name="pageSize">Item count for each page.</param>
        /// <typeparam name="T">The type of the element of source.</typeparam>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements of specific page index.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> or <paramref name="pageSize"/> is less or equals to 0.</exception>
        [Pure]
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