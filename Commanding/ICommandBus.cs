namespace Qubitus.Taygeta.Commanding
{
    public interface ICommandBus 
    {
        void Publish<TCommand, >(CommandMessage<T> command);
        void Publish<TCommand, TCallback>(CommandMessage<TCommand> command, CommandCallback<TCallback, TResult> callback)
            where TCallback : TCommand;

        Registration Subscribe(string commandName, MessageHandler<CommandMessage<object>> handler);

    }
}