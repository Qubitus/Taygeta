using System;
using Qubitus.Taygeta.Messaging;

namespace Qubitus.Taygeta.Serialization
{
    public class MessageSerializer : ISerializer
    {
        private readonly ISerializer _serializer;

        public IConverter Converter => _serializer.Converter;

        public MessageSerializer(ISerializer serializer)
        {
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer));

            _serializer = serializer;
        }

        public static ISerializedObject<TTarget> SerializePayload<TTarget>(IMessage message, ISerializer serializer)
        {
            var typedMessage = message as ISerializationAware;
            if (typedMessage != null)
                return typedMessage.SerializePayload<TTarget>(serializer);

            return serializer.Serialize<TTarget>(message.Payload);
        }

        public static ISerializedObject<TTarget> SerializeMetadata<TTarget>(IMessage message, ISerializer serializer)
        {
            var typedMessage = message as ISerializationAware;
            if (typedMessage != null)
                return typedMessage.SerializeMetadata<TTarget>(serializer);
            
            return serializer.Serialize<TTarget>(message.Metadata);
        }

        public bool CanSerializeTo<TTarget>() => _serializer.CanSerializeTo<TTarget>();

        public ISerializedObject<TTarget> Serialize<TTarget>(object source) 
            => _serializer.Serialize<TTarget>(source);

        public TTarget Deserialize<TSource, TTarget>(ISerializedObject<TSource> serializedObject) 
            => _serializer.Deserialize<TSource, TTarget>(serializedObject);
    }
}