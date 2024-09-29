using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Azure.Kusto;

[Experimental(EFDiagnostics.KustoVectorSearchExperimental)]
internal class Embedding : IEquatable<Embedding>
{
    public string? Path { get; set; }
    public VectorDataType DataType { get; set; }
    public int Dimensions { get; set; }
    public DistanceFunction DistanceFunction { get; set; }

    public bool Equals(Embedding? that)
        => Equals(Path, that?.Path) && Equals(DataType, that?.DataType) && Equals(Dimensions, that.Dimensions);
}
