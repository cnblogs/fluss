using System.Linq;
using Cnblogs.Fluss.Infrastructure;
using Cnblogs.Fluss.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cnblogs.Fluss.FunctionalTests
{
    public class FlussWebApplicationFactory : WebApplicationFactory<Startup>
    {
        /// <inheritdoc />
        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder().UseEnvironment("Test");
        }

        /// <inheritdoc />
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(
                services =>
                {
                    var dbDescriptor =
                        services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<BlogDbContext>));
                    services.Remove(dbDescriptor);
                    var conn = new SqliteConnection("Filename=:memory:;Foreign Keys=False");
                    conn.Open();
                    services.AddDbContext<BlogDbContext>(o => o.UseSqlite(conn));

                    using var scope = services.BuildServiceProvider().CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
                    db.Database.EnsureCreated();
                    SeedData.Seed(db);
                });
        }
    }
}