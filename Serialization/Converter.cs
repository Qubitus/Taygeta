using System;

namespace Qubitus.Taygeta.Serialization
{
    public abstract class Converter : IConverter
    {
        public bool CanConvert<TSource, TTarget>()
        {
            throw new NotImplementedException();
        }

        public abstract TTarget Convert<TTarget>(object source)
        {
            var methodInfo = typeof(Converter).GetMethod(nameof(Convert<TSource,TTarget>));
            
        }

        public TTarget Convert<TSource, TTarget>(object original)
        {
            throw new NotImplementedException();
        }

        public ISerializedObject<TTarget> Convert<TSource, TTarget>(ISerializedObject<TSource> original)
        {
            if (typeof(TSource) == typeof(TTarget))
                return (ISerializedObject<TTarget>) original;

            return new SimpleSerializedObject<TTarget>(Convert<TTarget>(original.Data), original.Type);
        }
    }
}