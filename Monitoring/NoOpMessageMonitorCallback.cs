using System;

namespace Qubitus.Taygeta.Monitoring
{
    public class NoOpMessageMonitorCallback : IMessageMonitorCallback
    {
        public static readonly NoOpMessageMonitorCallback Instance = new NoOpMessageMonitorCallback();

        private NoOpMessageMonitorCallback()
        {
        }
        
        public void ReportIgnored()
        {
            // Do nothing
        }

        public void ReportSuccess()
        {
            // Do nothing
        }

        public void ReportFailure(Exception exception)
        {
            // Do nothing
        }
    }
}