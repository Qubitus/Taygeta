namespace Qubitus.Taygeta.Common.Transaction
{
    public interface ITransaction 
    {
        void Commit();
        void Rollback();
    }
}