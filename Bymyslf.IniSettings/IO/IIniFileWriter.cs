using System.Text;

namespace Bymyslf.IniSettings.IO
{
    public interface IIniFileWriter
    {
        void Write(IniFile iniFile);

        void Write(IniFile iniFile, Encoding fileEncoding);
    }
}