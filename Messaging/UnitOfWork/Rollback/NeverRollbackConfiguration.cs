using System;

namespace Qubitus.Taygeta.Messaging.UnitOfWork.Rollback
{
    public class NeverRollbackConfiguration : IRollbackConfiguration
    {
        public bool RollbackOn(Exception exception)
        {
            return false;
        }
    }
}