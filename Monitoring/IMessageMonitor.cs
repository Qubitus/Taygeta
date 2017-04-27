using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Monitoring
{
    public interface IMessageMonitor<in TMessage>
        where TMessage : IMessage
    {
        IMessageMonitorCallback OnMessageIngested(TMessage message);
    }
}