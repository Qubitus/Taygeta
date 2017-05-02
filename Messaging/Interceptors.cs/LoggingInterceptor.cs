using System;

namespace Qubitus.Taygeta.Messaging.Interceptors
{
    public class LoggingInterceptor<TMessage> : IMessageHandlerInterceptor<TMessage>
        where TMessage : IMessage
    {
        private readonly ILogger _logger;

        public LoggingInterceptor(string loggerName)
        {
            _logger = LoggerFactory.GetLogger(loggerName);
        }

        public object Handle(UnitOfWork unitOfWork, InterceptorChain interceptorChain)
        {
            TMessage message = unitOfWork.GetMessage();
            _logger.Info($"Incoming message [{message.Payload.GetType().Name}]");
            try
            {
                var returnValue = interceptorChain.Proceed();
                _logger.Info($"[{message.Payload.GetType().Name}] executed successfully with a [{0}] return value",
                    (returnValue == null) ? "null" : returnValue.GetType().Name);
                return returnValue;
            }
            catch (Exception ex)
            {
                _logger.Warn($"[{message.Payload.GetType().Name}] execution failed:", ex);
                throw;
            }
        }
    }
}