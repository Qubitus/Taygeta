using System;

namespace Qubitus.Taygeta.Messaging.UnitOfWork.Rollback
{
    public interface IRollbackConfiguration
    {
        bool RollbackOn(Exception exception);
    }
}