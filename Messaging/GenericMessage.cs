using System.Collections.Generic;

namespace Qubitus.Taygeta.Messaging
{
    public class GenericMessage<T> : Message<T>
    {
        
        public T Payload { get; }
        
        public Metadata Metadata { get; }

        public GenericMessage(T payload)
            : this(payload, Metadata.Empty)
        {
        }

        public GenericMessage(T payload, IDictionary<string, object> metadata)
            : this(IdentifierFactory.Instance.Generate(), payload, CurrentUnitOfWork.CorrelationData.Union(metadata))
        {
        }

        public GenericMessage(string identifier, T payload, IDictionary<string, object> metadata)
            : base(identifier)
        {
            Payload = payload;
            Metadata = Metadata.From(metadata);
        }

        private Message(string identifier, T payload, Metadata metadata)
            : base(identifier)
        {
            Payload = payload;
            Metadata = metadata;
        }
    }
}