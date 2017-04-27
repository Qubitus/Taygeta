using System;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Monitoring
{
    public class NoOpMessageMonitor : IMessageMonitor<IMessage> 
    {
        public static readonly NoOpMessageMonitor Instance = new NoOpMessageMonitor();

        private NoOpMessageMonitor()
        {
        }

        public IMessageMonitorCallback OnMessageIngested(IMessage message)
        {
            return NoOpMessageMonitorCallback.Instance;
        }
    }
}