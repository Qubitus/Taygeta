namespace Qubitus.Taygeta.Common.Transaction
{
    internal class NoTransaction : ITransaction
    {
        public void Commit()
        {
            // Do nothing
        }

        public void Rollback()
        {
            // Do nothing
        }
    }
}