using System;
using System.Collections.Generic;

namespace FedoraDev.NoteGraphr.Core.UniqueID
{
    public static class UID
    {
        private static readonly Dictionary<uint, Object> _storage = new Dictionary<uint, object>();
        private static uint _nextID = 0;

        public static uint Add<T>(T obj)
        {
            uint id = _nextID;
            _storage.Add(id, obj);
            _nextID = GetNextAvailableID();
            return id;
        }

        public static T TryToGet<T>(uint id) where T: class
        {
            if (_storage.ContainsKey(id))
                return _storage[id] as T;
            return null;
        }

        public static void Remove(uint id)
        {
            _storage.Remove(id);
            if (_nextID > id)
                _nextID = id;
        }

        static uint GetNextAvailableID()
        {
            uint i = _nextID;

            while (_storage.ContainsKey(i))
                i++;

            return i;
        }
    }
}
