using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Kusto.Metadata.Internal;

namespace Microsoft.EntityFrameworkCore
{
    public static class KustoIndexBuilderExtensions
    {
        public static IndexBuilder ForVectors(this IndexBuilder indexBuilder, VectorIndexType? indexType)
        {
            indexBuilder.Metadata.SetVectorIndexType(indexType);

            return indexBuilder;
        }

        public static IndexBuilder<TEntity> ForVectors<TEntity>(
            this IndexBuilder<TEntity> indexBuilder,
            VectorIndexType? indexType)
            => (IndexBuilder<TEntity>)ForVectors((IndexBuilder)indexBuilder, indexType);

        public static IConventionIndexBuilder? ForVectors(
            this IConventionIndexBuilder indexBuilder,
            VectorIndexType? indexType,
            bool fromDataAnnotation = false)
        {
            if (indexBuilder.CanSetVectorIndexType(indexType, fromDataAnnotation))
            {
                indexBuilder.Metadata.SetVectorIndexType(indexType, fromDataAnnotation);
                return indexBuilder;
            }

            return null;
        }

        public static bool CanSetVectorIndexType(
            this IConventionIndexBuilder indexBuilder,
            VectorIndexType? indexType,
            bool fromDataAnnotation = false)
            => indexBuilder.CanSetAnnotation(KustoAnnotationNames.VectorIndexType, indexType, fromDataAnnotation);
    }
}
