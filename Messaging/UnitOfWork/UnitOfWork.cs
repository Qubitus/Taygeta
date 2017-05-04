using System;

namespace Qubitus.Taygeta.Messaging.UnitOfWork
{
    public abstract class UnitOfWork<TMessage> : IUnitOfWork<TMessage>
        where TMessage : IMessage
    {
        public bool IsActive
        {
            get
            {
                return Phase.IsStarted;
            }
        }



        public void Rollback()
        {
            Rollback(null);
        }

        public abstract TMessage Message { get; }
        public abstract Metadata CorrelationData { get; }

        public abstract Phase Phase { get; }
        public abstract IUnitOfWork<IMessage> Parent { get; }

        public abstract void Start();
        public abstract void Commit();
        public abstract void Rollback(Exception ex);

        public abstract void OnPrepareCommit(Action<IUnitOfWork<TMessage>> handler);
        public abstract void OnCommit(Action<IUnitOfWork<TMessage>> handler);
        public abstract void AfterCommit(Action<IUnitOfWork<TMessage>> handler);

        public abstract void OnRollback(Action<IUnitOfWork<TMessage>> handler);
        public abstract void OnCleanup(Action<IUnitOfWork<TMessage>> handler);
    }
}