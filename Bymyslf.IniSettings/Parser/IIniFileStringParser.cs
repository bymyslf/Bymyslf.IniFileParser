using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bymyslf.IniSettings.Parser
{
    public interface IIniFileStringParser
    {
        IniFile Parse(string iniFileString);
    }
}