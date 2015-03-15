using System;
using System.Collections.Generic;
using System.IO;

namespace Bymyslf.IniSettings.Parser
{
    public abstract class IniFileParserBase
    {
        protected readonly List<string> commentsListAux = new List<string>();
        protected string sectionAux;

        protected void ReadLine(string currentLine, IniFile file)
        {
            currentLine = currentLine.Trim();

            if (currentLine == String.Empty)
            {
                return;
            }

            if (IsCommentLine(currentLine))
            {
                commentsListAux.Add(currentLine.Substring(1, currentLine.Length - 1));
                return;
            }

            if (IsSectionLine(currentLine))
            {
                ProcessSection(currentLine, file);
                return;
            }

            if (IsKeyLine(currentLine))
            {
                ProcessKey(currentLine, file);
                return;
            }
        }

        protected virtual bool IsCommentLine(string currentLine)
        {
            return currentLine[0] == ';';
        }

        protected virtual bool IsSectionLine(string currentLine)
        {
            return currentLine[0] == '[' && currentLine[currentLine.Length - 1] == ']';
        }

        protected virtual bool IsKeyLine(string currentLine)
        {
            return currentLine.Contains("=");
        }

        protected void ProcessSection(string currentLine, IniFile file)
        {
            string sectionName = currentLine.Substring(1, currentLine.Length - 2);

            sectionAux = sectionName;

            if (file.Sections.ContainsSection(sectionName))
            {
                //TO DO: throw exception
            }

            file.Sections.AddSection(sectionName);
            file.Sections[sectionName].Comments = commentsListAux;

            commentsListAux.Clear();
        }

        protected void ProcessKey(string currentLine, IniFile file)
        {
            int indexOfSeparator = currentLine.IndexOf("=");
            string key = currentLine.Substring(0, indexOfSeparator);
            string value = currentLine.Substring(indexOfSeparator + 1);

            if (String.IsNullOrEmpty(sectionAux))
            {
                AddKeyToCollection(key, value, file.GlobalScope);
            }
            else
            {
                AddKeyToCollection(key, value, file.Sections[sectionAux].Keys);
            }
        }

        protected void AddKeyToCollection(string key, string value, IniKeyCollection keyCollection)
        {
            if (keyCollection.ContainsKey(key))
            {
                keyCollection[key].Value = value;
            }
            else
            {
                keyCollection.AddKey(key, value);
            }

            keyCollection[key].Comments = commentsListAux;
            commentsListAux.Clear();
        }
    }
}