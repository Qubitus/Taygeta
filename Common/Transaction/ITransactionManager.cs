using System;

namespace Qubitus.Taygeta.Common.Transaction
{
    public interface ITransactionManager
    {
        ITransaction StartTransaction();

        void ExecuteInTransaction(Action execute);
        T FetchInTransaction<T>(Func<T> retrieve);
    }
}