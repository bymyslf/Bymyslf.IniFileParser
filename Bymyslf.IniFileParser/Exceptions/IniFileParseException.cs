using System;

namespace Bymyslf.IniFileParser.Exceptions
{
    public class IniFileParseException : Exception
    {
        public IniFileParseException()
        {
        }

        public IniFileParseException(string message)
            : base(message)
        {
        }

        public IniFileParseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}