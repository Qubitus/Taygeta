namespace Qubitus.Taygeta.Commanding
{
    public class SimpleCommandBus : CommandBus
    {
        private static readonly ILogger Logger = LoggerFactory.GetLogger(typeof(SimpleCommandBus));

        public SimpleCommandBus()
            : this(NoTransactionManager.INSTANCE, NoOpMessageMonitor.INSTANCE)
        {
        }

        public SimpleCommandBus(ITransactionManager transactionManager,
            IMessageMonitor)
        {
        }
    }
}