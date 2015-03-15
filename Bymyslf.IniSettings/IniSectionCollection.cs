using System;
using System.Collections;
using System.Collections.Generic;

namespace Bymyslf.IniSettings
{
    public class IniSectionCollection : IEnumerable<IniSection>
    {
        private Dictionary<string, IniSection> sections;

        public IniSectionCollection()
        {
            this.sections = new Dictionary<string, IniSection>();
        }

        public IniSectionCollection(IniSectionCollection collection)
        {
            this.sections = new Dictionary<string, IniSection>(collection.sections);
        }

        public IniSection this[string sectionName]
        {
            get
            {
                if (sections.ContainsKey(sectionName))
                {
                    return sections[sectionName];
                }

                return null;
            }
        }

        public bool AddSection(string sectionName)
        {
            if (String.IsNullOrEmpty(sectionName))
            {
                throw new ArgumentException("sectionName cannot be null or empty!");
            }

            if (!ContainsSection(sectionName))
            {
                this.sections.Add(sectionName, new IniSection(sectionName));
                return true;
            }

            return false;
        }

        public bool ContainsSection(string sectionName)
        {
            return this.sections.ContainsKey(sectionName);
        }

        public int Count
        {
            get { return sections.Count; }
        }

        public void Clear()
        {
            this.sections.Clear();
        }

        public IEnumerator<IniSection> GetEnumerator()
        {
            foreach (string sectionName in sections.Keys)
            {
                yield return sections[sectionName];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}