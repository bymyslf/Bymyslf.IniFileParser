using System.Text;

namespace Bymyslf.IniFileParser.IO
{
    public interface IIniFileWriter
    {
        void Write(IniFile iniFile);

        void Write(IniFile iniFile, Encoding fileEncoding);
    }
}