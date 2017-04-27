using System;
using System.Collections.Generic;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Commanding
{
    public class GenericCommandMessage<TPayload> : MessageDecorator<TPayload>, ICommandMessage<TPayload>
    {
        public string CommandName { get; private set; }

        public GenericCommandMessage(TPayload payload)
            : this(payload, Metadata.Empty)
        {
        }

        public GenericCommandMessage(TPayload payload, IDictionary<string, object> metadata)
            : this(new GenericMessage(payload, metadata), typeof(T).Name)
        {
        }

        public GenericCommandMessage(IMessage<TPayload> message, string commandName)
            : base(message)
        {
            CommandName = commandName;
        }

        public override IMessage WithMetadata(IDictionary<string, object> metadata)
        {
            return new GenericCommandMessage<TPayload>(Delegate.WithMetadataTyped(metadata), CommandName);
        }

        public override IMessage WithMetadataUnion(IDictionary<string, object> metadata)
        {
            return new GenericCommandMessage<TPayload>(Delegate.WithMetadataUnionTyped(metadata), CommandName);
        }
    }
}