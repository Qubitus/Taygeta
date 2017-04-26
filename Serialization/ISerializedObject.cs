using System;

namespace Qubitus.Taygeta.Serialization
{
    public interface ISerializedObject
    {
        Type ContentType { get; }
        ISerializedType SerializedType { get; }

        object Content { get; }
    }

    public interface ISerializedObject<out T> : ISerializedObject
    {
        new T Content { get; }
    }
}