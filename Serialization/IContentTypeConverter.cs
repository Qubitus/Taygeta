using System;

namespace Qubitus.Taygeta.Serialization
{
    public interface IContentTypeConverter<TSource, TTarget>
    {
        Type SourceType { get; }
        Type TargetType { get; }

        TTarget Convert(TSource original);
    }
}