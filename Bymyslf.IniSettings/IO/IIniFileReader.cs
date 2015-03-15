using System.Text;

namespace Bymyslf.IniSettings.IO
{
    public interface IIniFileReader
    {
        IniFile Read();

        IniFile Read(Encoding fileEncoding);
    }
}