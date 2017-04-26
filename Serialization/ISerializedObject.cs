namespace Qubitus.Taygeta.Serialization
{
    public interface ISerializedObject
    {
        object Data { get; }
        ISerializedType Type { get; }
    }

    public interface ISerializedObject<out T> : ISerializedObject
    {
        new T Data { get; }
    }
}