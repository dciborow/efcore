using Azure.Core;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Kusto.Infrastructure.Internal;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Kusto.Tests
{
    public class KustoDbContextOptionsExtensionsTests
    {
        [Fact]
        public void UseKusto_with_action_configures_options()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseKusto(options =>
            {
                options.ClusterEndpoint = "https://example.kusto.windows.net";
                options.DatabaseName = "TestDatabase";
            });

            var extension = optionsBuilder.Options.FindExtension<KustoOptionsExtension>();
            Assert.NotNull(extension);
            Assert.Equal("https://example.kusto.windows.net", extension.ClusterEndpoint);
            Assert.Equal("TestDatabase", extension.DatabaseName);
        }

        [Fact]
        public void UseKusto_with_connection_string_configures_options()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseKusto("https://example.kusto.windows.net", "TestDatabase", "ClientId", "ClientSecret", "Authority");

            var extension = optionsBuilder.Options.FindExtension<KustoOptionsExtension>();
            Assert.NotNull(extension);
            Assert.Equal("https://example.kusto.windows.net", extension.ClusterEndpoint);
            Assert.Equal("TestDatabase", extension.DatabaseName);
            Assert.Equal("ClientId", extension.ApplicationClientId);
            Assert.Equal("ClientSecret", extension.ApplicationClientSecret);
            Assert.Equal("Authority", extension.Authority);
        }

        [Fact]
        public void UseKusto_with_token_credential_configures_options()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var tokenCredential = new DefaultAzureCredential();
            optionsBuilder.UseKusto("https://example.kusto.windows.net", tokenCredential, "TestDatabase");

            var extension = optionsBuilder.Options.FindExtension<KustoOptionsExtension>();
            Assert.NotNull(extension);
            Assert.Equal("https://example.kusto.windows.net", extension.ClusterEndpoint);
            Assert.Equal("TestDatabase", extension.DatabaseName);
            Assert.Equal(tokenCredential, extension.TokenCredential);
        }

        [Fact]
        public void UseKusto_with_connection_string_and_database_name_configures_options()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseKusto("ConnectionString", "TestDatabase");

            var extension = optionsBuilder.Options.FindExtension<KustoOptionsExtension>();
            Assert.NotNull(extension);
            Assert.Equal("ConnectionString", extension.ConnectionString);
            Assert.Equal("TestDatabase", extension.DatabaseName);
        }

        [Fact]
        public void UseKusto_with_cluster_endpoint_and_database_name_configures_options()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseKusto("https://example.kusto.windows.net", "TestDatabase", "ClientId", "ClientSecret", "Authority", options =>
            {
                options.ClusterEndpoint = "https://example.kusto.windows.net";
                options.DatabaseName = "TestDatabase";
            });

            var extension = optionsBuilder.Options.FindExtension<KustoOptionsExtension>();
            Assert.NotNull(extension);
            Assert.Equal("https://example.kusto.windows.net", extension.ClusterEndpoint);
            Assert.Equal("TestDatabase", extension.DatabaseName);
            Assert.Equal("ClientId", extension.ApplicationClientId);
            Assert.Equal("ClientSecret", extension.ApplicationClientSecret);
            Assert.Equal("Authority", extension.Authority);
        }

        [Fact]
        public void UseKusto_with_cluster_endpoint_and_token_credential_configures_options()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var tokenCredential = new DefaultAzureCredential();
            optionsBuilder.UseKusto("https://example.kusto.windows.net", tokenCredential, "TestDatabase", options =>
            {
                options.ClusterEndpoint = "https://example.kusto.windows.net";
                options.DatabaseName = "TestDatabase";
            });

            var extension = optionsBuilder.Options.FindExtension<KustoOptionsExtension>();
            Assert.NotNull(extension);
            Assert.Equal("https://example.kusto.windows.net", extension.ClusterEndpoint);
            Assert.Equal("TestDatabase", extension.DatabaseName);
            Assert.Equal(tokenCredential, extension.TokenCredential);
        }
    }
}
