namespace Qubitus.Taygeta.Serialization
{
    public interface ISerializer
    {
        bool CanSerializeTo<T>();

        SerializedObject<T> Serialize<T>(object source);

        T Deserialize<S, T>(SerializedObject<T> source);
    }
}