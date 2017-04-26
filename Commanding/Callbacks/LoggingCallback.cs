using System;

namespace Qubitus.Taygeta.Commanding.Callbacks
{
    public class LoggingCallback : ICommandCallback<object, object>
    {
        private static readonly ILogger Logger = LoggerFactory.GetLogger(typeof(LoggingCallback));
        public static readonly LoggingCallback INSTANCE = new LoggingCallback();

        private LoggingCallback() 
        {
        }

        public void OnSuccess(ICommandMessage<object> message, object result)
        {
            Logger.Info($"Command executed successfully: {message.CommandName}");
        }

        public void OnFailure(ICommandMessage<object> message, Exception exception)
        {
            Logger.Warn($"Command resulted in exception: {message.CommandName}", exception);
        }
    }
}