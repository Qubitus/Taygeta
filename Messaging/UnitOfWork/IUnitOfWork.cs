using System;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Messaging.UnitOfWork
{
    public interface IUnitOfWork<out TMessage>
        where TMessage : IMessage
    {
        TMessage Message { get; }
        Metadata CorrelationData { get; }

        Phase Phase { get; }
        IUnitOfWork<IMessage> Parent { get; }

        void Start();
        void Commit();

        void Rollback();
        void Rollback(Exception ex);
        
        void OnPrepareCommit(Action<IUnitOfWork<TMessage>> handler);
        void OnCommit(Action<IUnitOfWork<TMessage>> handler);
        void AfterCommit(Action<IUnitOfWork<TMessage>> handler);

        void OnRollback(Action<IUnitOfWork<TMessage>> handler);
        void OnCleanup(Action<IUnitOfWork<TMessage>> handler);

        TResult ExecuteWithResult<TResult>(Action<TResult> action, IRollbackConfiguration rollbackConfiguration);
    }
}