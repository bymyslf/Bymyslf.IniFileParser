using System;
using System.Collections.Generic;
using System.Text;

namespace Bymyslf.IniSettings.Formatting
{
    public class IniFileFormatter : IIniFileFormatter
    {
        public IniFileFormatter()
        {
        }

        public string Format(IniFile iniFile)
        {
            var sb = new StringBuilder();

            WriteKeys(sb, iniFile.GlobalScope);

            foreach (var section in iniFile.Sections)
            {
                WriteSection(sb, section);
            }

            return sb.ToString();
        }

        protected virtual void WriteSection(StringBuilder sb, IniSection section)
        {
            if (sb.Length > 0)
            {
                sb.AppendLine();
            }

            WriteComments(sb, section.Comments);

            sb.AppendLine(String.Format("[{0}]", section.Name));

            WriteKeys(sb, section.Keys);
        }

        protected virtual void WriteKeys(StringBuilder sb, IniKeyCollection keys)
        {
            foreach (var key in keys)
            {
                WriteComments(sb, key.Comments);

                sb.AppendLine(String.Format("{0}={1}", key.Key, key.Value));
            }
        }

        protected virtual void WriteComments(StringBuilder sb, IList<string> comments)
        {
            foreach (var comment in comments)
            {
                sb.AppendLine(String.Format(";{0}", comment));
            }
        }
    }
}