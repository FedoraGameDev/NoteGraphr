using System;
using System.Collections.Generic;

namespace FedoraDev.NoteGraphr.Core.IDTrackers
{
    public static class IDTracker
    {
        private static readonly Dictionary<uint, Object> _storage = new Dictionary<uint, object>();
        private static uint _nextID = 0;

        public static uint Add<T>(T obj)
        {
            _storage.Add(_nextID, obj);
            return _nextID++;
        }

        public static T TryToGet<T>(uint id) where T: class
        {
            return _storage[id] as T;
        }
    }
}
