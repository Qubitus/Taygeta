using System;

namespace Qubitus.Taygeta.Serialization
{
    public class SimpleSerializedObject<T> : ISerializedObject<T>
    {
        public T Data { get; }
        public ISerializedType Type { get; }

        public SimpleSerializedObject(T data, ISerializedType type)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            Data = data;
            Type = type;
        }

        public override bool Equals (object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            var typedObj = (SimpleSerializedObject<T>) obj;
            return object.Equals(Data, typedObj.Data) && object.Equals(Type, typedObj.Type);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 486187739;
                hash = (hash * 16777619) ^ Data.GetHashCode();
                hash = (hash * 16777619) ^ Type.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"{nameof(SimpleSerializedObject<T>)}[{Type}]";
        }
    }
}