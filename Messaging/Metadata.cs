using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Qubitus.Taygeta.Messaging
{
    public class Metadata : ReadOnlyDictionary<string, object>
    {
        public static Metadata Empty { get; } = new Metadata();

        private Metadata()
            : this(new Dictionary<string, object>())
        {
        }

        private Metadata(IDictionary<string, object> dictionary) 
            : base(dictionary)
        {
        }

        public Metadata And(string key, object value)
        {
            var dictionary = new Dictionary<string, object>(this);
            dictionary[key] = value; // Add or overwrite
            return new Metadata(dictionary);
        }

        public Metadata AndIfNotPresent(string key, object value)
        {
            return Dictionary.ContainsKey(key) ? this : this.And(key, value);
        }

        public Metadata Union(IDictionary<string, object> target)
        {
            if (!target.Any())
                return this;
            if (!this.Any())
                return From(target);
            
            var dictionary = new Dictionary<string, object>(this);
            foreach (var kv in target)
                dictionary[kv.Key] = kv.Value;
            return new Metadata(dictionary);
        }

        public Metadata Exclude(HashSet<string> keys)
        {
            if (!keys.Any())
                return this;
            
            var dictionary = new Dictionary<string, object>(this);
            foreach (var key in keys)
                dictionary.Remove(key);
            return new Metadata(dictionary);
        }

        public Metadata Intersect(HashSet<string> keys)
        {
            var filteredPairs = this.Where(kv => keys.Contains(kv.Key));
            return new Metadata(filteredPairs.ToDictionary(kv => kv.Key, kv => kv.Value));
        }

        public static Metadata From(string key, object value)
        {
            return new Metadata(new Dictionary<string, object> { { key, value } });
        }

        public static Metadata From(IDictionary<string, object> metadata)
        {
            if (metadata == null || !metadata.Any())
                return Metadata.Empty;

            var result = metadata as Metadata;
            if (result == null)
                result = new Metadata(metadata);

            return result;
        }
    }
}