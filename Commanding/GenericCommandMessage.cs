using System;
using System.Collections.Generic;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Commanding
{
    public class GenericCommandMessage<T> : MessageDecorator<T>, ICommandMessage<T>
    {
        public string CommandName { get; private set; }

        public GenericCommandMessage(T payload)
            : this(payload, Metadata.Empty)
        {
        }

        public GenericCommandMessage(T payload, IDictionary<string, object> metadata)
            : this(new GenericMessage(payload, metadata), typeof(T).Name)
        {
        }

        public GenericCommandMessage(IMessage<T> message, string commandName)
            : base(message)
        {
            CommandName = commandName;
        }

        public new GenericCommandMessage<T> WithMetadata(IDictionary<string, object> metadata)
        {
            return new GenericCommandMessage<T>(Delegate.WithMetadata(metadata), CommandName);
        }

        public new GenericCommandMessage<T> WithMetadataUnion(IDictionary<string, object> metadata)
        {
            return new GenericCommandMessage<T>(Delegate.WithMetadataUnion(metadata), CommandName);
        }

        ICommandMessage ICommandMessage.WithMetadata(IDictionary<string, object> metadata) => WithMetadata(metadata);
        ICommandMessage ICommandMessage.WithMetadataUnion(IDictionary<string, object> metadata) => WithMetadataUnion(metadata);
        ICommandMessage<T> ICommandMessage<T>.WithMetadata(IDictionary<string, object> metadata) => WithMetadata(metadata);
        ICommandMessage<T> ICommandMessage<T>.WithMetadataUnion(IDictionary<string, object> metadata) => WithMetadataUnion(metadata);

        IMessage<T> IMessage<T>.WithMetadata(IDictionary<string, object> metadata) => WithMetadata(metadata);
        IMessage<T> IMessage<T>.WithMetadataUnion(IDictionary<string, object> metadata) => WithMetadata(metadata);
    }
}