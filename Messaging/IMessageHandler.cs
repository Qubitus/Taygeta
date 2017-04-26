namespace Qubitus.Taygeta.Messaging
{
    public interface IMessageHandler<T>
        where T : IMessage
    {
        object Handle(T message);
    }
}