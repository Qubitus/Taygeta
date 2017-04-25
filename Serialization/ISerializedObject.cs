namespace Qubitus.Taygeta.Serialization
{
    public interface ISerializedObject<T>
    {
        T Data { get; }
        ISerializedType Type { get; }
    }
}