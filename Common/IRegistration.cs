using System;

namespace Qubitus.Taygeta.Common
{
    public interface IRegistration : IDisposable
    {
        bool Cancel();
    }
}