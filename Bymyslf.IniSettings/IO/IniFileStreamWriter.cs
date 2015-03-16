using Bymyslf.IniSettings.Formatter;
using System;
using System.IO;
using System.Text;

namespace Bymyslf.IniSettings.IO
{
    public class IniFileStreamWriter : IIniFileWriter
    {
        private readonly string path;
        private readonly IIniFileFormatter formatter;

        public IniFileStreamWriter(string path)
            : this(path, new IniFileFormatter())
        {
        }

        public IniFileStreamWriter(string path, IIniFileFormatter formatter)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path cannot be null or empty");
            }

            if (formatter == null)
            {
                throw new ArgumentNullException("formatter cannot be null");
            }

            this.path = path;
            this.formatter = formatter;
        }

        public void Write(IniFile iniFile)
        {
            throw new NotImplementedException();
        }

        public void Write(IniFile iniFile, Encoding fileEncoding)
        {
            throw new NotImplementedException();
        }
    }
}