namespace Qubitus.Taygeta.Messaging
{
    public interface IInterceptorChain
    {
        object Proceed();
    }
}