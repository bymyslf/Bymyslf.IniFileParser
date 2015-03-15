using System.IO;

namespace Bymyslf.IniSettings.Parser
{
    public interface IIniFileStreamParser
    {
        IniFile Parse(StreamReader iniFileSream);
    }
}