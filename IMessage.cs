namespace Qubitus.Taygeta.Messaging
{
    public interface IMessage<T>
    {
        string Identifier { get; }

        Metadata Metadata { get; }

        T Payload { get; }        
    }
}
