using Microsoft.EntityFrameworkCore.Kusto.Extensions;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Kusto.Tests
{
    public class KustoDbFunctionsExtensionsTests
    {
        [Fact]
        public void IsDefined_ThrowsInvalidOperationException()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.IsDefined(null));
        }

        [Fact]
        public void CoalesceUndefined_ThrowsInvalidOperationException()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.CoalesceUndefined(null, null));
        }

        [Fact]
        public void VectorDistance_ThrowsInvalidOperationException_ForByteVectors()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.VectorDistance(new ReadOnlyMemory<byte>(), new ReadOnlyMemory<byte>()));
        }

        [Fact]
        public void VectorDistance_ThrowsInvalidOperationException_ForByteVectors_WithBruteForce()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.VectorDistance(new ReadOnlyMemory<byte>(), new ReadOnlyMemory<byte>(), true));
        }

        [Fact]
        public void VectorDistance_ThrowsInvalidOperationException_ForByteVectors_WithBruteForceAndDistanceFunction()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.VectorDistance(new ReadOnlyMemory<byte>(), new ReadOnlyMemory<byte>(), true, DistanceFunction.Euclidean));
        }

        [Fact]
        public void VectorDistance_ThrowsInvalidOperationException_ForSByteVectors()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.VectorDistance(new ReadOnlyMemory<sbyte>(), new ReadOnlyMemory<sbyte>()));
        }

        [Fact]
        public void VectorDistance_ThrowsInvalidOperationException_ForSByteVectors_WithBruteForce()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.VectorDistance(new ReadOnlyMemory<sbyte>(), new ReadOnlyMemory<sbyte>(), true));
        }

        [Fact]
        public void VectorDistance_ThrowsInvalidOperationException_ForSByteVectors_WithBruteForceAndDistanceFunction()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.VectorDistance(new ReadOnlyMemory<sbyte>(), new ReadOnlyMemory<sbyte>(), true, DistanceFunction.Euclidean));
        }

        [Fact]
        public void VectorDistance_ThrowsInvalidOperationException_ForFloatVectors()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.VectorDistance(new ReadOnlyMemory<float>(), new ReadOnlyMemory<float>()));
        }

        [Fact]
        public void VectorDistance_ThrowsInvalidOperationException_ForFloatVectors_WithBruteForce()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.VectorDistance(new ReadOnlyMemory<float>(), new ReadOnlyMemory<float>(), true));
        }

        [Fact]
        public void VectorDistance_ThrowsInvalidOperationException_ForFloatVectors_WithBruteForceAndDistanceFunction()
        {
            var dbFunctions = new DbFunctions();
            Assert.Throws<InvalidOperationException>(() => dbFunctions.VectorDistance(new ReadOnlyMemory<float>(), new ReadOnlyMemory<float>(), true, DistanceFunction.Euclidean));
        }
    }
}
