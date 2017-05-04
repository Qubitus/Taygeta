using System.Collections.Generic;
using System.Linq;

namespace Qubitus.Taygeta.Messaging.UnitOfWork
{
    public sealed class Phase
    {
        public Phase this[PhaseName name]
        {
            get
            {
                return collection.FirstOrDefault(x => x.Name == name);
            }
        }

        private static readonly HashSet<Phase> collection = new HashSet<Phase>
            {
                { new Phase(PhaseName.NotStarted, false, false) },
                { new Phase(PhaseName.Started, false, false) },
                { new Phase(PhaseName.PrepareCommit, true, false) },
                { new Phase(PhaseName.Commit, true, false) },
                { new Phase(PhaseName.Rollback, true, true) },
                { new Phase(PhaseName.AfterCommit, true, true) },
                { new Phase(PhaseName.Cleanup, false, true) },
                { new Phase(PhaseName.Closed, false, true) },
            };

        public PhaseName Name { get; }
        public bool IsStarted { get; }
        public bool ReverseCallbackOrder { get; }

        private Phase(PhaseName name, bool isStarted, bool reverseCallbackOrder)
        {
            Name = name;
            IsStarted = isStarted;
            ReverseCallbackOrder = reverseCallbackOrder;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    public enum PhaseName
    {
        NotStarted,
        Started,
        PrepareCommit,
        Commit,
        Rollback,
        AfterCommit,
        Cleanup,
        Closed,
    }
}