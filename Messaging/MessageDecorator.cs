using System;
using System.Collections.Generic;

namespace Qubitus.Taygeta.Messaging
{
    public abstract class MessageDecorator<T> : IMessage<T>
    {
        protected IMessage<T> Message;

        public string Identifier => Message.Identifier;

        public T Payload => Message.Payload;

        public Metadata Metadata => Message.Metadata;

        protected MessageDecorator(IMessage<T> message)
        {
            Message = message;
        }




        object IMessage.Payload => throw new NotImplementedException();

        public IMessage<T> WithMetadata(IDictionary<string, object> metadata)
        {
            throw new NotImplementedException();
        }

        public IMessage<T> WithMetadataUnion(IDictionary<string, object> metadata)
        {
            throw new NotImplementedException();
        }

        IMessage IMessage.WithMetadata(IDictionary<string, object> metadata)
        {
            throw new NotImplementedException();
        }

        IMessage IMessage.WithMetadataUnion(IDictionary<string, object> metadata)
        {
            throw new NotImplementedException();
        }
    }
}

