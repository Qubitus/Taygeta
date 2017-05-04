using System.Collections.Concurrent;
using Qubitus.Taygeta.Common.Transaction;
using Qubitus.Taygeta.Messaging;
using Qubitus.Taygeta.Monitoring;

namespace Qubitus.Taygeta.Commanding
{
    public class SimpleCommandBus : ICommandBus
    {
        private static readonly ILogger Logger = LoggerFactory.GetLogger(typeof(SimpleCommandBus));

        private readonly ConcurrentDictionary<string, IMessageHandler<IMessage>> subscription = 
            new ConcurrentDictionary<string, IMessageHandler<IMessage>>();
        private readonly SynchronizedCollection<IMessageHandlerInterceptor

        protected ITransactionManager TransactionManager { get; }
        protected IMessageMonitor MessageMonitor { get; }

        public SimpleCommandBus()
            : this(NoTransactionManager.Instance, NoOpMessageMonitor.Instance)
        {
        }

        public SimpleCommandBus(ITransactionManager transactionManager, IMessageMonitor<ICommandMessage<object>> messageMonitor)
        {
            TransactionManager = transactionManager;
            MessageMonitor = messageMonitor;
        }

        public void Dispatch<TCommand, TResult>(ICommandMessage<TCommand> command, ICommandCallback<TCommand, TResult> callback)
        {
            DoDispatch(Intercept(command), callback);
        }

        protected CommandMessage<TCommand> Intercept<TCommand>(ICommandMessage<TCommand> command)
        {
            ICommandMessage<TCommand> commandToDispatch = command;
            foreach(var interceptor in dispatchInterceptors)
                commandToDispatch = interceptor.Handle(commandToDispatch);
        }
    }
}