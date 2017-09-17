using System;
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

        protected Message(string identifier)
        {
            Identifier = identifier;
        }

        protected abstract IMessage WithMetadata(Metadata metadata);

        IMessage IMessage.WithMetadata(IDictionary<string, object> metadata)
        {
            if (Metadata.Equals(metadata))
                return this;
            
            return WithMetadata(Metadata.From(metadata));
        }

        IMessage IMessage.WithMetadataUnion(IDictionary<string, object> metadata)
        {
            if (!metadata.Any())
                return this;
            
            return WithMetadata(Metadata.Union(metadata));
        }
    }
}
