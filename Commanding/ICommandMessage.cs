using System.Collections.Generic;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Commanding
{
    public interface ICommandMessage : IMessage
    {
        string CommandName { get; }

        new ICommandMessage WithMetadata(IDictionary<string, object> metadata);
        new ICommandMessage WithMetadataUnion(IDictionary<string, object> metadata);
    }

    public interface ICommandMessage<out T> : ICommandMessage, IMessage<T>
    {
        new ICommandMessage<T> WithMetadata(IDictionary<string, object> metadata);
        new ICommandMessage<T> WithMetadataUnion(IDictionary<string, object> metadata);
    }
}