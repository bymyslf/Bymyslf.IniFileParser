using System;
using System.Collections.Generic;

namespace Bymyslf.IniSettings
{
    public class IniKey
    {
        public IniKey(string key)
            : this(key, string.Empty)
        {
        }

        public IniKey(string key, string value)
        {
            this.key = key;
            this.value = value;
            this.comments = new List<string>();
        }

        private string key;

        public string Key
        {
            get { return this.key; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Key cannot be null or empty");
                }

                this.key = value;
            }
        }

        private string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private List<string> comments;

        public List<string> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}