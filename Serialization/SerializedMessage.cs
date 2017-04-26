using System;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Serialization
{
    public class SerializedMessage<T> : Message<T>, ISerializationAware
        where T : class
    {
        private readonly LazyDeserializingObject<T> _payload;
        private readonly LazyDeserializingObject<Metadata> _metadata;

        public bool IsPayloadDeserialized => _payload.IsDeserialized;
        public bool IsMetadataDeserialized => _metadata.IsDeserialized;
        public override T Payload => _payload.DeserializedObject;
        public override Metadata Metadata => _metadata.DeserializedObject;

        public SerializedMessage(string identifier, 
            ISerializedObject<object> serializedPayload, 
            ISerializedObject<object> serializedMetadata, 
            ISerializer serializer)
            : this(identifier, 
                new LazyDeserializingObject<T>(serializedPayload, serializer),
                new LazyDeserializingObject<Metadata>(serializedMetadata, serializer))
        {
        }

        public SerializedMessage(string identifier,
            LazyDeserializingObject<T> payload,
            LazyDeserializingObject<Metadata> metadata)
            : base(identifier)
        {
            _payload = payload;
            _metadata = metadata;
        }

        private SerializedMessage(SerializedMessage<T> message, LazyDeserializingObject<Metadata> newMetadata)
            : this(message.Identifier, message._payload, newMetadata)
        {
        }

        protected override Message<T> WithMetadata(Metadata metadata)
        {
            if (Metadata.Equals(metadata))
                return this;

            return new SerializedMessage<T>(this, new LazyDeserializingObject<Metadata>(metadata));
        }

        public ISerializedObject<TTarget> SerializePayload<TTarget>(ISerializer serializer)
        {
            if (serializer.Equals(_payload.Serializer))
                return serializer.Converter.Convert<TTarget>(_payload.SerializedObject);

            return serializer.Serialize<TTarget>(_payload.DeserializedObject);
        }

        public ISerializedObject<TTarget> SerializeMetadata<TTarget>(ISerializer serializer)
        {
            if (serializer.Equals(_metadata.Serializer))
                return serializer.Converter.Convert<TTarget>(_metadata.SerializedObject);

            return serializer.Serialize<TTarget>(_metadata.DeserializedObject);
        }
    }
}