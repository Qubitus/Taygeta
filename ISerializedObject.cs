using System;

namespace Qubitus.Taygeta.Serialization
{
    public interface ISerializedObject<T> 
    {
        T Data { get; }
        
        Type DataType { get; }

        SerializedType  { get; }        
    }
}