using System;

namespace Qubitus.Taygeta.Common
{
    public abstract class Registration : IRegistration
    {
        public abstract bool Cancel();

        public void Dispose()
        {
            Cancel();
        }
    }
}