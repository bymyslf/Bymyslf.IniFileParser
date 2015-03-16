using Bymyslf.IniFileParser.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bymyslf.IniFileParser.IO
{
    public class IniFileInMemoryReader : IIniFileReader
    {
        private readonly string filePath;
        private readonly IIniFileStringParser parser;

        public IniFileInMemoryReader(string path)
            : this(path, new IniFileStringParser())
        {
        }

        public IniFileInMemoryReader(string path, IIniFileStringParser parser)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path cannot be null or empty");
            }

            if (parser == null)
            {
                throw new ArgumentNullException("parser cannot be null");
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
                        return parser.Parse(sr.ReadToEnd());
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