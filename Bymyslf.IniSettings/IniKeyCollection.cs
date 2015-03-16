using System;
using System.Collections;
using System.Collections.Generic;

namespace Bymyslf.IniSettings
{
    public class IniKeyCollection : IEnumerable<IniKey>
    {
        private Dictionary<string, IniKey> keys;

        public IniKeyCollection()
        {
            this.keys = new Dictionary<string, IniKey>();
        }

        public IniKeyCollection(IniKeyCollection collection)
        {
            this.keys = new Dictionary<string, IniKey>(collection.keys);
        }

        public IniKey this[string keyName]
        {
            get
            {
                if (keys.ContainsKey(keyName))
                {
                    return keys[keyName];
                }

                return null;
            }

            set
            {
                if (!keys.ContainsKey(keyName))
                {
                    this.AddKey(keyName);
                }
            }
        }

        public bool AddKey(string keyName)
        {
            if (String.IsNullOrEmpty(keyName))
            {
                throw new ArgumentException("keyName cannot be null or empty");
            }

            if (!ContainsKey(keyName))
            {
                this.keys.Add(keyName, new IniKey(keyName));
                return true;
            }

            return false;
        }

        public bool AddKey(string keyName, string keyValue)
        {
            if (AddKey(keyName))
            {
                if (String.IsNullOrEmpty(keyValue))
                {
                    throw new ArgumentException("keyValue cannot be null or empty");
                }

                this.keys[keyName].Value = keyValue;
                return true;
            }

            return false;
        }

        public bool ContainsKey(string keyName)
        {
            return this.keys.ContainsKey(keyName);
        }

        public int Count
        {
            get { return keys.Count; }
        }

        public IEnumerator<IniKey> GetEnumerator()
        {
            foreach (string key in keys.Keys)
            {
                yield return keys[key];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}