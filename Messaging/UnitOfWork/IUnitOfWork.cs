using System;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.UnitOfWork
{
    public interface IUnitOfWork<TMessage>
        where TMessage : IMessage
    {
        TMessage Message { get; }
        Metadata CorrelationData { get; }
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

    }

    public abstract class UnitOfWork<TMessage> : IUnitOfWork<TMessage>
        where TMessage : IMessage
    {
        public bool IsRoot 
        {
            get
            {
                return Parent == null;
            }
        }
        public void Rollback()
        {
            Rollback(null);
        }

        void OnPrepareSubmit(Action<IUnitOfWork<)

    }
}