using System;
using System.Collections.Generic;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Serialization
{
    public class SerializedObjectHolder : ISerializationAware
    {
        private readonly IMessage _message;

        private readonly object payloadLock = new object();
        private readonly IDictionary<ISerializer, ISerializedObject> serializedPayload 
            = new Dictionary<ISerializer, ISerializedObject>();

        private readonly object metadataLock = new object();
        private readonly IDictionary<ISerializer, ISerializedObject> serializedMetadata
            = new Dictionary<ISerializer, ISerializedObject>();

        public SerializedObjectHolder(IMessage message)
        {
            _message = message;
        }

        public ISerializedObject<TTarget> SerializePayload<TTarget>(ISerializer serializer)
        {
            lock(payloadLock)
            {
                ISerializedObject payload;
                if (serializedPayload.TryGetValue(serializer, out payload))
                    serializer.Converter.Convert<TTarget>(payload);

                var serialized = MessageSerializer.SerializePayload<TTarget>(_message, serializer);
                serializedPayload.Add(serializer, serialized);
                return serialized;
            }
        }

        public ISerializedObject<TTarget> SerializeMetadata<TTarget>(ISerializer serializer)
        {
            lock(metadataLock)
            {
                ISerializedObject metadata;
                if (serializedMetadata.TryGetValue(serializer, out metadata))
                    serializer.Converter.Convert<TTarget>(metadata);

                var serialized = MessageSerializer.SerializeMetadata<TTarget>(_message, serializer);
                serializedMetadata.Add(serializer, serialized);
                return serialized;
            }
        }
    }
}