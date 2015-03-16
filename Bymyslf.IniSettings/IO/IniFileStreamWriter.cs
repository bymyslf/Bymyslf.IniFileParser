using Bymyslf.IniSettings.Formatting;
using System;
using System.IO;
using System.Text;

namespace Bymyslf.IniSettings.IO
{
    public class IniFileStreamWriter : IIniFileWriter
    {
        private readonly string filePath;
        private readonly IIniFileFormatter formatter;

        public IniFileStreamWriter(string filePath)
            : this(filePath, new IniFileFormatter())
        {
        }

        public IniFileStreamWriter(string filePath, IIniFileFormatter formatter)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("filePath cannot be null or empty");
            }

            if (formatter == null)
            {
                throw new ArgumentNullException("formatter cannot be null");
            }

            this.filePath = filePath;
            this.formatter = formatter;
        }

        public void Write(IniFile iniFile)
        {
            Write(iniFile, Encoding.Default);
        }

        public void Write(IniFile iniFile, Encoding fileEncoding)
        {
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, fileEncoding))
                    {
                        sw.Write(formatter.Format(iniFile));
                    }
                }
            }
            catch (IOException ex)
            {
                throw;
            }
        }
    }
}