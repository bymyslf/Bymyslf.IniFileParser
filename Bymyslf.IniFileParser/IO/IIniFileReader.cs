using System.Text;

namespace Bymyslf.IniFileParser.IO
{
    public interface IIniFileReader
    {
        IniFile Read();

        IniFile Read(Encoding fileEncoding);
    }
}