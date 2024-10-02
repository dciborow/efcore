using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Kusto;

/// <summary>
///     Defines the distance function for a vector index specification in the Azure Data Explorer (Kusto) service.
/// </summary>
[Experimental(EFDiagnostics.KustoVectorSearchExperimental)]
public enum DistanceFunction
{
    /// <summary>
    ///     Represents the Euclidean distance function.
    /// </summary>
    [EnumMember(Value = "euclidean")]
    Euclidean,

    /// <summary>
    ///     Represents the cosine distance function.
    /// </summary>
    [EnumMember(Value = "cosine")]
    Cosine,

    /// <summary>
    ///     Represents the dot product distance function.
    /// </summary>
    [EnumMember(Value = "dotproduct")]
    DotProduct,
}
