using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Kusto.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Kusto.Storage.Internal;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Kusto.Tests
{
    public class KustoDatabaseFacadeExtensionsTests
    {
        [Fact]
        public void GetKustoClient_ReturnsClient()
        {
            var options = new DbContextOptionsBuilder()
                .UseKusto("https://mycluster.kusto.windows.net", "MyDatabase", "clientId", "clientSecret", "authority")
                .Options;

            using var context = new TestKustoDbContext(options);
            var client = context.Database.GetKustoClient();

            Assert.NotNull(client);
        }

        [Fact]
        public void GetKustoDatabaseId_ReturnsDatabaseId()
        {
            var options = new DbContextOptionsBuilder()
                .UseKusto("https://mycluster.kusto.windows.net", "MyDatabase", "clientId", "clientSecret", "authority")
                .Options;

            using var context = new TestKustoDbContext(options);
            var databaseId = context.Database.GetKustoDatabaseId();

            Assert.Equal("MyDatabase", databaseId);
        }

        [Fact]
        public void IsKusto_ReturnsTrue_WhenUsingKusto()
        {
            var options = new DbContextOptionsBuilder()
                .UseKusto("https://mycluster.kusto.windows.net", "MyDatabase", "clientId", "clientSecret", "authority")
                .Options;

            using var context = new TestKustoDbContext(options);
            var isKusto = context.Database.IsKusto();

            Assert.True(isKusto);
        }

        private class TestKustoDbContext : DbContext
        {
            public TestKustoDbContext(DbContextOptions options)
                : base(options)
            {
            }
        }
    }
}
