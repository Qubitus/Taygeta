namespace Qubitus.Taygeta.Serialization
{
    public interface ISerializationAware
    {
        ISerializedObject<TTarget> SerializePayload<TTarget>(ISerializer serializer);
        ISerializedObject<TTarget> SerializeMetadata<TTarget>(ISerializer serializer);
    }
}
