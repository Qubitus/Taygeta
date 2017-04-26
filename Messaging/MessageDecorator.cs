using System;
using System.Collections.Generic;
using Qubitus.Taygeta.Serialization;

namespace Qubitus.Taygeta.Messaging
{
    public abstract class MessageDecorator<T> : IMessage<T>, ISerializationAware
    {
        private volatile SerializedObjectHolder _serializedObjectHolder;

        protected IMessage<T> Delegate;
        public string Identifier => Delegate.Identifier;
        object IMessage.Payload => Payload;
        public T Payload => Delegate.Payload;
        public Metadata Metadata => Delegate.Metadata;

        private SerializedObjectHolder SerializedObjectHolder
        {
            get
            {
                if (_serializedObjectHolder == null)
                    _serializedObjectHolder = new SerializedObjectHolder(Delegate);
                
                return _serializedObjectHolder;
            }
        }

        protected MessageDecorator(IMessage<T> message)
        {
            Delegate = message;
        }

        public ISerializedObject<TTarget> SerializePayload<TTarget>(ISerializer serializer)
        {
            var typedDelegate = Delegate as ISerializationAware;
            if (typedDelegate != null)
                return typedDelegate.SerializePayload<TTarget>(serializer);

            return SerializedObjectHolder.SerializePayload<TTarget>(serializer);
        }

        public ISerializedObject<TTarget> SerializeMetadata<TTarget>(ISerializer serializer)
        {
            var typedDelegate = Delegate as ISerializationAware;
            if (typedDelegate != null)
                return typedDelegate.SerializeMetadata<TTarget>(serializer);
            
            return SerializedObjectHolder.SerializeMetadata<TTarget>(serializer);
        }

        protected abstract MessageDecorator<T> WithMetadata(IDictionary<string, object> metadata);
        protected abstract MessageDecorator<T> WithMetadataUnion(IDictionary<string, object> metadata);

        IMessage IMessage.WithMetadata(IDictionary<string, object> metadata) => WithMetadata(metadata);
        IMessage IMessage.WithMetadataUnion(IDictionary<string, object> metadata) => WithMetadataUnion(metadata);

        IMessage<T> IMessage<T>.WithMetadata(IDictionary<string, object> metadata) => WithMetadata(metadata);
        IMessage<T> IMessage<T>.WithMetadataUnion(IDictionary<string, object> metadata) => WithMetadataUnion(metadata);
    }
}

