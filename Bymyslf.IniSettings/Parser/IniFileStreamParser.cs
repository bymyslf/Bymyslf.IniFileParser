using System.IO;

namespace Bymyslf.IniSettings.Parser
{
    public class IniFileStreamParser : IniFileParserBase, IIniFileStreamParser
    {
        public IniFile Parse(StreamReader iniFileStream)
        {
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