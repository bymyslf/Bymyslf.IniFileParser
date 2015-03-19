using Bymyslf.IniFileParser.Exceptions;
using System;

namespace Bymyslf.IniFileParser.Parsing
{
    public class IniFileStringParser : IniFileParserBase, IIniFileStringParser
    {
        public IniFile Parse(string iniFileString)
        {
            if (String.IsNullOrEmpty(iniFileString))
            {
                throw new ArgumentException("iniFileString cannot be null or empty");
            }

            IniFile file = new IniFile();

            commentsListAux.Clear();
            sectionAux = null;

            try
            {
                var lines = iniFileString.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var currentLine in lines)
                {
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