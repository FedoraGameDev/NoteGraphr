using FedoraDev.NoteGraphr.Core.UniqueID;
using System.Collections.Generic;

namespace FedoraDev.NoteGraphr.Core.Graph
{
    public class GraphSheet
    {
        public uint ID { get; }

        private List<IGraphable> _storage = new List<IGraphable>();

        public GraphSheet()
        {
            ID = UID.AddAndGetID(this);
        }

        public void Add(IGraphable graphable)
        {
            _storage.Add(graphable);
        }

        public bool Contains(IGraphable graphable)
        {
            return _storage.Contains(graphable);
        }

        public void Remove(IGraphable graphable)
        {
            _storage.Remove(graphable);
        }
    }
}
