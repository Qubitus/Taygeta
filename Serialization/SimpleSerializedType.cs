using System;

namespace Qubitus.Taygeta.Serialization
{
    public class SimpleSerializedType : ISerializedType
    {
        public string Name { get; }
        public string Revision { get; }
        
        public SimpleSerializedType(string name, string revision)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Name = name;
            Revision = revision;
        }

        public override bool Equals (object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            var typedObj = (SimpleSerializedType) obj;
            return object.Equals(Name, typedObj.Name) && object.Equals(Revision, typedObj.Revision);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 486187739;
                hash = (hash * 16777619) ^ Name.GetHashCode();
                hash = (hash * 16777619) ^ Revision.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"{nameof(SimpleSerializedType)}[{Name}] (revision {Revision})";
        }
    }
}