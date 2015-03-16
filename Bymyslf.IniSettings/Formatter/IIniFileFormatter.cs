using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bymyslf.IniSettings.Formatter
{
    public interface IIniFileFormatter
    {
        string Format(IniFile iniFile);
    }
}