using System;
using System.Collections.Generic;

namespace Bymyslf.IniSettings
{
    public class IniSection
    {
        public IniSection(string name)
            : this(name, null)
        { }

        public IniSection(string name, IDictionary<string, IniKeyValuePair> keyValuePairs)
        {
            this.name = name;

            if (keyValuePairs == null)
            {
                this.keyValuePairs = new Dictionary<string, IniKeyValuePair>();
            }
            else
            {
                this.keyValuePairs = keyValuePairs;
            }
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        private IDictionary<string, IniKeyValuePair> keyValuePairs;

        public ICollection<IniKeyValuePair> KeyValuePairs
        {
            get { return this.keyValuePairs.Values; }
        }

        private IniStatus status;

        public IniStatus Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public string this[string key]
        {
            get
            {
                if (!this.keyValuePairs.ContainsKey(key))
                {
                    throw new ArgumentNullException();
                }

                return this.keyValuePairs[key].Value;
            }
            set
            {
                if (!this.keyValuePairs.ContainsKey(key))
                {
                    throw new ArgumentNullException();
                }

                this.status = IniStatus.Modified;
                this.keyValuePairs[key].Value = value;
            }
        }

        public void Add(string key)
        {
            this.Add(key, "");
        }

        public void Add(string key, string value)
        {
            this.status = IniStatus.Modified;
            this.keyValuePairs.Add(key, new IniKeyValuePair(this, key, value, IniStatus.Inserted));
        }

        public void Remove()
        {
            this.status = IniStatus.Removed;
        }

        public void Remove(string key)
        {
            if (String.IsNullOrEmpty(key) || !this.keyValuePairs.ContainsKey(key))
            {
                throw new ArgumentException();
            }

            this.status = IniStatus.Modified;
            this.keyValuePairs[key].Remove();
        }
    }
}