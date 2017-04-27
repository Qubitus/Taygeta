using System;
using Qubitus.Taygeta.Commanding.Callbacks;
using Qubitus.Taygeta.Common;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Commanding
{
    public abstract class CommandBus : ICommandBus
    {
        public void Publish<TCommand>(ICommandMessage<TCommand> command)
            where TCommand : class
        {
            Publish<TCommand, object>(command, LoggingCallback.Instance);
        }

        public abstract void Publish<TCommand, TResult>(ICommandMessage<TCommand> command, ICommandCallback<TCommand, TResult> callback)
            where TCommand : class;
        public abstract IRegistration Subscribe<TCommandMessage>(string commandName, IMessageHandler<TCommandMessage> handler)
            where TCommandMessage : ICommandMessage;
    }
}