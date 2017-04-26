using System.Collections.Generic;
using System.Linq;

namespace Qubitus.Taygeta.Messaging
{
    public abstract class Message<T> : IMessage<T> 
    {
        public string Identifier { get; }
        object IMessage.Payload => Payload;
        public abstract T Payload { get; }
        public abstract Metadata Metadata { get; }

        public Message(string identifier)
        {
            Identifier = identifier;
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

        IMessage IMessage.WithMetadata(IDictionary<string, object> metadata) => WithMetadata(metadata);
        IMessage IMessage.WithMetadataUnion(IDictionary<string, object> metadata) => WithMetadataUnion(metadata);
    }
}
