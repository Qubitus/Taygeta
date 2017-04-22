using System.Collections.Generic;
using System.Linq;

namespace Qubitus.Taygeta.Messaging
{
    public abstract class Message<T> : IMessage<T> 
    {
        public string Identifier { get; }

        public abstract T Payload { get; }
        object IMessage.Payload => Payload;

        public abstract Metadata Metadata { get; }

        public Message(string identifier)
        {
            Identifier = identifier;
        }

        IMessage IMessage.WithMetadata(IDictionary<string, object> metadata)
        {
            return WithMetadata(metadata);
        }

        IMessage IMessage.WithMetadataUnion(IDictionary<string, object> metadata)
        {
            return WithMetadataUnion(metadata);
        }

        public IMessage<T> WithMetadata(IDictionary<string, object> metadata)
        {
            if (Metadata.Equals(metadata))
                return this;
            
            return WithMetadata(Metadata.From(metadata));
        }

        public IMessage<T> WithMetadataUnion(IDictionary<string, object> metadata)
        {
            if (!metadata.Any())
                return this;
            
            return WithMetadata(Metadata.Union(metadata));
        }

        protected abstract Message<T> WithMetadata(Metadata metadata);
    }
}
