namespace Qubitus.Taygeta.Serialization
{
    public interface IConverter
    {
        bool CanConvert<TSource, TTarget>();

        TTarget Convert<TTarget>(object source);
        TTarget Convert<TSource, TTarget>(object original);
        
        ISerializedObject<TTarget> Convert<TTarget>(ISerializedObject<object> original);
    }
}