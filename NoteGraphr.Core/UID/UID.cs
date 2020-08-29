using System.Collections.Generic;

namespace NoteGraphr.Core.UniqueID
{
    public static class UID
    {
        private static readonly Dictionary<uint, object> _storage = new Dictionary<uint, object>();
        private static uint _nextID = 0;

        public static uint AddAndGetID<T>(T obj)
        {
            Add(obj);
            uint id = _nextID;
            SetNextAvailableID();
            return id;
        }

        static void Add<T>(T obj)
        {
            _storage.Add(_nextID, obj);
        }

        public static bool Contains<T>(T obj)
        {
            return _storage.ContainsValue(obj);
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

        static void SetNextAvailableID()
        {
            while (_storage.ContainsKey(_nextID))
                _nextID++;
        }
    }
}
