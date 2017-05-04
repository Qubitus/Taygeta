namespace Qubitus.Taygeta.Messaging.UnitOfWork
{
    public static class EUnitOfWork
    {
        public static bool IsRoot<TMessage>(this IUnitOfWork<TMessage> uow)
            where TMessage : IMessage
        {
            return uow.Parent != null;
        }

        public static IUnitOfWork<IMessage> GetRoot<TMessage>(this IUnitOfWork<TMessage> uow)
            where TMessage : IMessage
        {
            if (uow.Parent == null)
                return (IUnitOfWork<IMessage>)uow;

            return uow.Parent.GetRoot();
        }

        public static TResult ExecuteWithResult<TMessage, TResult>(this IUnitOfWork<TMessage> uow, Action<TResult> action)
        {
            return uow.ExecuteWithResult(action, RollbackConfigurationType.AN)
        }
    }
}
