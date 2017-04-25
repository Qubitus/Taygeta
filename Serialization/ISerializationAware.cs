namespace Qubitus.Taygeta.Serialization
{
    public interface ISerializationAware
    {
        ISerializedObject<T> SerializePayload<T>(Serializer serializer);
        ISerializedObject<T> SerializeMetadata<T>(Serializer serializer);
    }
}
