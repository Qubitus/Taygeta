using System;
using System.Linq;
using System.Reflection;

namespace Qubitus.Taygeta.Serialization
{
    public abstract class Converter : IConverter
    {
        public abstract bool CanConvert<TSource, TTarget>();

        private readonly MethodInfo _convertMethodInfo = typeof(Converter).GetRuntimeMethods()
            .Where(x => x.Name == nameof(Convert))
            .Where(x => x.GetGenericArguments().Count() == 2)
            .First();
        public TTarget Convert<TTarget>(object source)
        {
            var methodInfo = _convertMethodInfo.MakeGenericMethod(source.GetType(), typeof(TTarget));
            return (TTarget) methodInfo.Invoke(this, new[] {source});
        }

        public abstract TTarget Convert<TSource, TTarget>(TSource original);

        public ISerializedObject<TTarget> Convert<TTarget>(ISerializedObject original)
        {
            if (original.ContentType == typeof(TTarget))
                return (ISerializedObject<TTarget>) original;
            
            return new SimpleSerializedObject<TTarget>(Convert<TTarget>(original.Content), original.SerializedType));
        }
    }
}