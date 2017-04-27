using System.Collections.Generic;

namespace Qubitus.Taygeta.Messaging
{
    public interface IMessage
    {
        string Identifier { get; }
        object Payload { get; }
        Metadata Metadata { get; }

        IMessage WithMetadata(IDictionary<string, object> metadata);
        IMessage WithMetadataUnion(IDictionary<string, object> metadata);
    }

    public interface IMessage<out T> : IMessage
    {
        new T Payload { get; }
    }
}
