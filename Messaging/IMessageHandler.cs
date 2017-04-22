namespace Qubitus.Taygeta.Messaging
{
    public interface MessageHandler<T>
        where T : IMessage
    {
        object Handle(T message);
    }
}