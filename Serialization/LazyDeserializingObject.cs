using System;
using System.Threading;

namespace Qubitus.Taygeta.Serialization
{
    public class LazyDeserializingObject<T>
        where T : class
    {
        private T _deserializedObject;
        private Func<ISerializedObject<object>> _serializedObject;

        public ISerializer Serializer { get; }
        public ISerializedObject<object> SerializedObject => _serializedObject();
        public T DeserializedObject 
        {
             get
             {
                if (!IsDeserialized)
                {
                    var value = Serializer.Deserialize<object, T>(SerializedObject);
                    Interlocked.Exchange<T>(ref _deserializedObject, value);
                }
                return _deserializedObject;
             }
        }

        public bool IsDeserialized
        {
            get
            {
                return _deserializedObject != null;
            }
        }

        public LazyDeserializingObject(T deserializedObject)
        {
            if (deserializedObject == null)
                throw new ArgumentNullException(nameof(deserializedObject));
            
            Serializer = null;
            _serializedObject = null;
            _deserializedObject = deserializedObject;
        }

        public LazyDeserializingObject(ISerializedObject<object> serializedObject, ISerializer serializer)
            : this(() => serializedObject, serializer)
        {
        }

        public LazyDeserializingObject(Func<ISerializedObject<object>> serializedObject, ISerializer serializer)
        {
            if (serializedObject == null)
                throw new ArgumentNullException(nameof(serializedObject));
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer));

            Serializer = serializer;
            _serializedObject = serializedObject;
        }
    } 
}