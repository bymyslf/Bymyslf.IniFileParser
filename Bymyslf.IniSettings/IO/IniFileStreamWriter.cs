using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bymyslf.IniSettings.IO
{
    public class IniFileStreamWriter : IIniFileWriter
    {
        private readonly string path;

        public IniFileStreamWriter(string path)
        {
            this.path = path;
        }

        public void Write()
        {
            throw new NotImplementedException();
        }

        public void Write(Encoding fileEncoding)
        {
            throw new NotImplementedException();
        }
    }
}