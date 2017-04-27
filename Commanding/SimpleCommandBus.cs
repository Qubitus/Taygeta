using Qubitus.Taygeta.Common.Transaction;
using Qubitus.Taygeta.Monitoring;

namespace Qubitus.Taygeta.Commanding
{
    public class SimpleCommandBus : CommandBus
    {
        private static readonly ILogger Logger = LoggerFactory.GetLogger(typeof(SimpleCommandBus));

        public SimpleCommandBus()
            : this(NoTransactionManager.Instance, NoOpMessageMonitor.Instance)
        {
        }

        public SimpleCommandBus(ITransactionManager transactionManager, IMessageMonitor<ICommandMessage<object>> messageMonitor)
        {
            
        }
    }
}