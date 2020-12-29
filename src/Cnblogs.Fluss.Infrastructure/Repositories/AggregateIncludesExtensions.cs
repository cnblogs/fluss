using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Cnblogs.Fluss.Infrastructure.Repositories
{
    internal static class AggregateIncludesExtensions
    {
        public static IQueryable<TEntity> AggregateIncludes<TEntity>(
            this IQueryable<TEntity> query,
            IEnumerable<Expression<Func<TEntity, object?>>> includes)
            where TEntity : class
            => includes.Aggregate(query, (queryable, include) => queryable.Include(include));
    }
}