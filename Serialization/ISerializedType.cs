namespace Qubitus.Taygeta.Serialization
{
    public interface ISerializedType
    {
        string Name { get; }
        string Revision { get; }
    }
}