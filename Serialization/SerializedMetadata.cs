using System;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Serialization
{
    public class SerializedMetadata<T> : ISerializedObject<T>
    {
        private readonly SimpleSerializedObject<T> _delegate;

        public T Data => _delegate.Data;
        public ISerializedType Type => _delegate.Type;

        public SerializedMetadata(T data)
        {
            _delegate = new SimpleSerializedObject<T>(data, new SimpleSerializedType(nameof(Metadata), null));
        }

        public override bool Equals (object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            var typedObj = (SerializedMetadata<T>)obj;
            return object.Equals(_delegate, typedObj);
        }
        
        public override int GetHashCode()
        {
            return _delegate.GetHashCode();
        }
    }
}