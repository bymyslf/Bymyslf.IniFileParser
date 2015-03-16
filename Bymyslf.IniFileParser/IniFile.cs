using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bymyslf.IniFileParser
{
    public class IniFile
    {
        public IniFile()
        {
            this.sections = new IniSectionCollection();
            this.globalScope = new IniKeyCollection();
        }

        public IniSection this[string sectionName]
        {
            get
            {
                if (!this.sections.ContainsSection(sectionName))
                {
                    throw new IndexOutOfRangeException();
                }

                return this.sections[sectionName];
            }
        }

        private IniKeyCollection globalScope;

        public IniKeyCollection GlobalScope
        {
            get { return globalScope; }
        }

        private IniSectionCollection sections;

        public IniSectionCollection Sections
        {
            get { return sections; }
            set { sections = value; }
        }
    }
}