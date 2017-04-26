namespace Qubitus.Taygeta.Messaging
{
    public static class EMessage
    {
        public static TMessage WithMetadata2<TMessage>(this TMessage message, Metadata metadata)
            where TMessage : IMessage
        {
            return (TMessage)message.WithMetadata(metadata);
        }
    }

}