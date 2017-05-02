namespace Qubitus.Taygeta.Messaging
{
    public interface IMessageHandlerInterceptor<TMessage>
        where TMessage : IMessage
    {
        object Handle(UnitOfWork unitOfWork, InterceptorChain interceptorChain);
    }
}