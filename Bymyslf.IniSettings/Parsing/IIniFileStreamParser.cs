using System.IO;

namespace Bymyslf.IniSettings.Parsing
{
    public interface IIniFileStreamParser
    {
        IniFile Parse(StreamReader iniFileSream);
    }
}