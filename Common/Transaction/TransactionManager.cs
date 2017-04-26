using System;

namespace Qubitus.Taygeta.Common.Transaction
{
    public abstract class TransactionManager : ITransactionManager
    {
        public abstract ITransaction StartTransaction();

        public void ExecuteInTransaction(Action execute)
        {
            var transaction = StartTransaction();
            try
            {
                execute();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public T FetchInTransaction<T>(Func<T> retrieve)
        {
            var transaction = StartTransaction();
            try
            {
                var result = retrieve();
                transaction.Commit();
                return result;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}