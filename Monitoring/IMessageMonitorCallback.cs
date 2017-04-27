using System;

namespace Qubitus.Taygeta.Monitoring
{
    public interface IMessageMonitorCallback
    {
        void ReportIgnored();
        void ReportSuccess();
        void ReportFailure(Exception exception);
    }
}