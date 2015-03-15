using System.Text;

namespace Bymyslf.IniSettings.IO
{
    public interface IIniFileWriter
    {
        void Write();

        void Write(Encoding fileEncoding);
    }
}