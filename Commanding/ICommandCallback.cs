using System;

namespace Qubitus.Taygeta.Commanding
{
    public interface ICommandCallback<in TCommand, TResult>
    {
        void OnSuccess(ICommandMessage<TCommand> message, TResult result);
        void OnFailure(ICommandMessage<TCommand> message, Exception exception);
    }
}