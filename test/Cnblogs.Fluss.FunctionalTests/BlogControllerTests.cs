using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Cnblogs.Fluss.FunctionalTests
{
    public class BlogControllerTests : IClassFixture<FlussWebApplicationFactory>
    {
        private readonly FlussWebApplicationFactory _fixture;

        public BlogControllerTests(FlussWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Home_GetBlogPostList()
        {
            // Arrange
            var client = _fixture.CreateClient();

            // Act
            var response = await client.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            content.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task PostDetail_GetPostDetail()
        {
            // Arrange
            var client = _fixture.CreateClient();

            // Act
            var response = await client.GetAsync("/p/1.html");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            content.Should().NotBeNullOrEmpty();
        }
    }
}