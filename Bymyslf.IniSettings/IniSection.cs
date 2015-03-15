using System;
using System.Collections.Generic;

namespace Bymyslf.IniSettings
{
    public class IniSection
    {
        public IniSection(string name)
            : this(name, null)
        { }

        public IniSection(string name, IniKeyCollection keys)
        {
            this.name = name;
            this.keys = keys ?? new IniKeyCollection();
            this.comments = new List<string>();
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        private IniKeyCollection keys;

        public IniKeyCollection Keys
        {
            get { return this.keys; }
        }

        private List<string> comments;

        public List<string> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}