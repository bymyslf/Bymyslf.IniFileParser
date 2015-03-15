using Bymyslf.IniSettings.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bymyslf.IniSettings.IO
{
    public class IniFileStreamReader : IIniFileReader
    {
        private readonly string filePath;
        private readonly IIniFileStreamParser parser;

        private List<string> commentsListAux;
        private string sectionAux;

        public IniFileStreamReader(string path)
            : this(path, new IniFileStreamParser())
        {
        }

        public IniFileStreamReader(string path, IIniFileStreamParser parser)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("File path cannot be null or empty!");
            }

            if (parser == null)
            {
                throw new ArgumentException("Parser cannot be null!");
            }

            this.filePath = path;
            this.parser = parser;
        }

        public IniFile Read()
        {
            return Read(Encoding.Default);
        }

        public IniFile Read(Encoding fileEncoding)
        {
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs, fileEncoding))
                    {
                        return parser.Parse(sr);
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