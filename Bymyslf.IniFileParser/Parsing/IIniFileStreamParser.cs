using System.IO;

namespace Bymyslf.IniFileParser.Parsing
{
    public interface IIniFileStreamParser
    {
        IniFile Parse(StreamReader iniFileSream);
    }
}