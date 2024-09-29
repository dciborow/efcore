using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.Utilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Kusto.Tests
{
    public class KustoIndexBuilderExtensionsTests
    {
        [Fact]
        public void ForVectors_SetsVectorIndexType()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var entityBuilder = modelBuilder.Entity<TestEntity>();
            var indexBuilder = entityBuilder.HasIndex(e => e.VectorProperty);

            indexBuilder.ForVectors(VectorIndexType.Flat);

            Assert.Equal(VectorIndexType.Flat, indexBuilder.Metadata.GetVectorIndexType());
        }

        [Fact]
        public void ForVectors_SetsVectorIndexType_WithEntityType()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var entityBuilder = modelBuilder.Entity<TestEntity>();
            var indexBuilder = entityBuilder.HasIndex(e => e.VectorProperty);

            indexBuilder.ForVectors<TestEntity>(VectorIndexType.Flat);

            Assert.Equal(VectorIndexType.Flat, indexBuilder.Metadata.GetVectorIndexType());
        }

        [Fact]
        public void ForVectors_SetsVectorIndexType_WithConvention()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var entityBuilder = modelBuilder.Entity<TestEntity>();
            var indexBuilder = entityBuilder.HasIndex(e => e.VectorProperty).Metadata.Builder;

            indexBuilder.ForVectors(VectorIndexType.Flat, fromDataAnnotation: true);

            Assert.Equal(VectorIndexType.Flat, indexBuilder.Metadata.GetVectorIndexType());
        }

        [Fact]
        public void CanSetVectorIndexType_ReturnsTrue()
        {
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var entityBuilder = modelBuilder.Entity<TestEntity>();
            var indexBuilder = entityBuilder.HasIndex(e => e.VectorProperty).Metadata.Builder;

            var canSet = indexBuilder.CanSetVectorIndexType(VectorIndexType.Flat, fromDataAnnotation: true);

            Assert.True(canSet);
        }

        private class TestEntity
        {
            public int Id { get; set; }
            public byte[] VectorProperty { get; set; }
        }
    }
}
