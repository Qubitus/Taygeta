using System;

namespace Qubitus.Taygeta.Common.Transaction
{
    public class NoTransactionManager : TransactionManager
    {
        public static readonly ITransactionManager Instance = new NoTransactionManager();

        private static readonly ITransaction _transaction = new NoTransaction();

        private NoTransactionManager()
        {
        }

        public override ITransaction StartTransaction()
        {
            return _transaction;
        }
    }
}