using System;

namespace Qubitus.Taygeta.Messaging.UnitOfWork.Rollback
{
    public class RollbackOnExceptionConfiguration : IRollbackConfiguration
    {
        public bool RollbackOn(Exception exception)
        {
            return true;
        }
    }
}