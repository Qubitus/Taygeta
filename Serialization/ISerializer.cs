namespace Qubitus.Taygeta.Serialization
{
    public interface Serializer
    {
        ISerializedObject<TTarget> Serialize<TTarget>(object source);

        bool CanSerializeTo<TTarget>();

        TTarget Deserialize<TSource, TTarget>(ISerializedObject<TSource> serializedObject);
    }
}