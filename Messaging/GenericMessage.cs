using System;
using System.Collections.Generic;

namespace Qubitus.Taygeta.Messaging
{
    public class GenericMessage<T> : Message<T>
    {
        public override T Payload { get; }
        
        public override Metadata Metadata { get; }

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

        public GenericMessage(GenericMessage<T> original, Metadata metadata)
            : base(original.Identifier)
        {
            Payload = original.Payload;
            Metadata = metadata;
        }

        protected override Message<T> WithMetadata(Metadata metadata)
        {
            return new GenericMessage<T>(this, metadata);
        }
    }
}