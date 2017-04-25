using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Commanding
{
    public interface ICommandMessage<T> : IMessage<T>
    {
        string CommandName { get; }
    }
}