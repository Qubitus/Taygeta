namespace Qubitus.Taygeta.Serialization
{
    public interface IConverter
    {
        bool CanConvert<TSource, TTarget>();

        TTarget Convert<TTarget>(object source);
        TTarget Convert<TSource, TTarget>(TSource original);
        
        ISerializedObject<TTarget> Convert<TTarget>(ISerializedObject original);
    }
}