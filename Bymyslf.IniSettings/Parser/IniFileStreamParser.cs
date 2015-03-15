using System;
using System.IO;

namespace Bymyslf.IniSettings.Parser
{
    public class IniFileStreamParser : IniFileParserBase, IIniFileStreamParser
    {
        public IniFile Parse(StreamReader iniFileStream)
        {
            if (iniFileStream == null)
            {
                throw new ArgumentNullException("iniFileStream cannot be null!");
            }

            IniFile file = new IniFile();

            commentsListAux.Clear();
            sectionAux = null;

            while (iniFileStream.Peek() >= 0)
            {
                string currentLine = iniFileStream.ReadLine();
                ReadLine(currentLine, file);
            }

            return file;
        }
    }
}