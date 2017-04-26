using System;

namespace Qubitus.Taygeta.Commanding.Attributes
{
    public class CommandHandlerAttribute : Attribute
    {
        public string CommandName { get; }
        public string RoutingKey { get; }
        public Type PayloadType { get; }
    }
}