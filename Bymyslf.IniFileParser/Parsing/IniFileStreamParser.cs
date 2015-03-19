using Bymyslf.IniFileParser.Exceptions;
using System;
using System.IO;

namespace Bymyslf.IniFileParser.Parsing
{
    public class IniFileStreamParser : IniFileParserBase, IIniFileStreamParser
    {
        public IniFile Parse(StreamReader iniFileStream)
        {
            if (iniFileStream == null)
            {
                throw new ArgumentNullException("iniFileStream cannot be null");
            }

            IniFile file = new IniFile();

            commentsListAux.Clear();
            sectionAux = null;

            try
            {
                while (iniFileStream.Peek() >= 0)
                {
                    string currentLine = iniFileStream.ReadLine();
                    ReadLine(currentLine, file);
                }
            }
            catch (Exception ex)
            {
                throw new IniFileParseException("Couldn't parse the file!", ex);
            }

            return file;
        }
    }
}