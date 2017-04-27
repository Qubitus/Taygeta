using System.Collections.Generic;

namespace Qubitus.Taygeta.Messaging
{
    public static class EMessage
    {
        public static TMessage WithMetadataTyped<TMessage>(this TMessage message, IDictionary<string, object> metadata)
            where TMessage : IMessage
        {
            return (TMessage)message.WithMetadata(metadata);
        }

        public static TMessage WithMetadataUnionTyped<TMessage>(this TMessage message, IDictionary<string, object> metadata)
            where TMessage : IMessage
        {
            return (TMessage)message.WithMetadataUnion(metadata);
        }
    }
}