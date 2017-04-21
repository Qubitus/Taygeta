using System;

namespace Qubitus.Taygeta.CommandHandling
{
    public interface CommandMessage<T> : Message<T>
    {
        string CommandName { get; }
    }
}
