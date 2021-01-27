using System;
using System.Collections.Generic;
using System.Linq;
using Cnblogs.Fluss.Infrastructure;
using FluentAssertions;
using Xunit;

namespace Cnblogs.Fluss.UnitTests.Infrastructure
{
    public class QueryExtensionTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void PageIndex_NegativeOrZero_Throw(int pageIndex)
        {
            // Arrange
            var queryable = GetTestQueryable();

            // Act
            Func<List<int>> act = () => queryable.Page(pageIndex, 10).ToList();

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void PageSize_NegativeOrZero_Throw(int pageSize)
        {
            // Arrange
            var queryable = GetTestQueryable();

            // Act
            Func<List<int>> act = () => queryable.Page(1, pageSize).ToList();

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(1000, 1000)]
        public void NormalCase_GetPagedData(int pageIndex, int pageSize)
        {
            // Arrange
            var queryable = GetTestQueryable();

            // Act
            var result = queryable.Page(pageIndex, pageSize).ToList();

            // Assert
            result.Should().BeEquivalentTo(queryable.Skip((pageIndex - 1) * pageSize).Take(pageSize));
        }

        private static IQueryable<int> GetTestQueryable() => Enumerable.Range(0, 100).AsQueryable();
    }
}