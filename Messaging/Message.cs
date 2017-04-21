using System;

namespace Qubitus.Taygeta.Messaging
{
    public class Message<T> : IMessage<T> 
    {
        public string Identifier { get; private set; }

        public Metadata<T> Metadata { get; private set; }

        public T Payload { get; private set; }

        public Message(string identifier)
        {
            Identifier = identifier;
        }

        public Message(T payload)
            : this(payload, Metadata.Empty)
        {
        }
        
        public Message(Message original, Metadata<T> metadata)
            : this(original.Identifier, original.Payload, Metadata.From(metadata))
        {
        }

        public Message(string identifier, T payload, Metadata<T> metadata)
        {
            Identifier = identifier;
            Payload = payload
            Metadata = metadata;
        }
    }
}
