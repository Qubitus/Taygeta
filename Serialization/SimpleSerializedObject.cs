using System;

namespace Qubitus.Taygeta.Serialization
{
    public class SimpleSerializedObject<T> : ISerializedObject<T>
    {
        public T Content { get; }
        object ISerializedObject.Content => Content;

        public Type ContentType => typeof(T);
        public ISerializedType SerializedType { get; }

        public SimpleSerializedObject(T data, ISerializedType type)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            Content = data;
            SerializedType = type;
        }

        public override bool Equals (object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            var typedObj = (SimpleSerializedObject<T>) obj;
            return object.Equals(Content, typedObj.Content) && 
                object.Equals(SerializedType, typedObj.SerializedType);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 486187739;
                hash = (hash * 16777619) ^ Content.GetHashCode();
                hash = (hash * 16777619) ^ SerializedType.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"{nameof(SimpleSerializedObject<T>)}[{SerializedType}]";
        }
    }
}