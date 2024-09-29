using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xunit;

namespace EFCore.Kusto.Tests
{
    public class KustoEntityTypeBuilderExtensionsTests
    {
        private class TestEntity
        {
            public int Id { get; set; }
        }

        [Fact]
        public void ToContainer_SetsContainerName()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<TestEntity>();

            entityBuilder.ToContainer("TestContainer");

            var containerName = entityBuilder.Metadata.GetContainer();
            Assert.Equal("TestContainer", containerName);
        }

        [Fact]
        public void HasPartitionKey_SetsPartitionKey()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<TestEntity>();

            entityBuilder.HasPartitionKey(e => e.Id);

            var partitionKey = entityBuilder.Metadata.GetPartitionKeyPropertyName();
            Assert.Equal(nameof(TestEntity.Id), partitionKey);
        }

        [Fact]
        public void UseETagConcurrency_SetsETagConcurrency()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<TestEntity>();

            entityBuilder.UseETagConcurrency();

            var etagConcurrency = entityBuilder.Metadata.GetETagConcurrency();
            Assert.True(etagConcurrency);
        }
    }
}
