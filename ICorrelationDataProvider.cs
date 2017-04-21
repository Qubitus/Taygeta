using System.Collections.Generic;

namespace Qubitus.Taygeta.Messaging
{
    public interface ICorrelationDataProvider {
        IDictionary<string, T> Generate<T>(IMessage<T> message);
    }
}