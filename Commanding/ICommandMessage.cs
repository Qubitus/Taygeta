using System.Collections.Generic;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Commanding
{
    public interface ICommandMessage : IMessage
    {
        string CommandName { get; }
    }

    public interface ICommandMessage<out T> : ICommandMessage, IMessage<T>
    {
    }
}