using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bymyslf.IniSettings
{
    public class IniFile
    {
        public IniFile()
        {
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

        public IniKeyCollection GlobalScope { get; private set; }

        private IniSectionCollection sections;

        public IniSectionCollection Sections
        {
            get { return sections; }
            set { sections = value; }
        }
    }
}