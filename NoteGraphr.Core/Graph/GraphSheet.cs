using System;
using System.Collections.Generic;
using System.Text;

namespace FedoraDev.NoteGraphr.Core.Graph
{
    public class GraphSheet
    {
        List<IGraphable> storage = new List<IGraphable>();

        public void Add(IGraphable graphable)
        {
            storage.Add(graphable);
        }

        public bool Contains(IGraphable graphable)
        {
            return storage.Contains(graphable);
        }

        public void Remove(IGraphable graphable)
        {
            storage.Remove(graphable);
        }
    }
}
