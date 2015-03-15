using System;

namespace Bymyslf.IniSettings.Parser
{
    public class IniFileStringParser : IniFileParserBase, IIniFileStringParser
    {
        public IniFile Parse(string iniFileString)
        {
            if (String.IsNullOrEmpty(iniFileString))
            {
                throw new ArgumentException("iniFileString cannot be null or empty!");
            }

            IniFile file = new IniFile();

            commentsListAux.Clear();
            sectionAux = null;

            var lines = iniFileString.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var currentLine in lines)
            {
                ReadLine(currentLine, file);
            }

            return file;
        }
    }
}