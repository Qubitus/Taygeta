namespace Qubitus.Taygeta.Serialization
{
    public interface ISerializer
    {
        IConverter Converter { get; }
        
        bool CanSerializeTo<TTarget>();
        
        ISerializedObject<TTarget> Serialize<TTarget>(object source);
        TTarget Deserialize<TSource, TTarget>(ISerializedObject<TSource> serializedObject);
    }
}