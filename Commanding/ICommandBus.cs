using Qubitus.Taygeta.Common;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Commanding
{
    public interface ICommandBus 
    {
        void Publish<TCommand>(ICommandMessage<TCommand> command)
            where TCommand : class;
        void Publish<TCommand, TResult>(ICommandMessage<TCommand> command, ICommandCallback<TCommand, TResult> callback)
            where TCommand : class;
        IRegistration Subscribe<TCommandMessage>(string commandName, IMessageHandler<TCommandMessage> handler)
            where TCommandMessage : ICommandMessage;
    }
}