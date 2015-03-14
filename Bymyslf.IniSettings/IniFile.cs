using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Bymyslf.IniSettings
{
    public class IniFile
    {
        /// <summary>
        /// Create a new IniFile instance.
        /// </summary>
        public IniFile(string filePath)
            : this(filePath, false)
        { }

        /// <summary>
        /// Create a new IniFile instance.
        /// </summary>
        public IniFile(string filePath, bool createFile)
        {
            if (!createFile && !File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            if (createFile)
            {
                File.Create(filePath);
            }

            this.FilePath = filePath;
            this.status = IniStatus.Unchanged;

            this.GetProfileString();
        }

        /// <summary>
        /// Gets the entire section through a given index.
        /// </summary>
        public IniSection this[string section]
        {
            get
            {
                if (!this.sections.ContainsKey(section)
                    || this.sections[section].Status == IniStatus.Removed)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.sections[section];
            }
        }

        public string this[string section, string key]
        {
            get
            {
                if (!this.sections.ContainsKey(section)
                    || this.sections[section].Status == IniStatus.Removed)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.sections[section][key];
            }
        }

        private string filePath;

        /// <summary>
        /// Get initialization file path.
        /// </summary>
        public string FilePath
        {
            get { return this.filePath; }
            protected set { this.filePath = value; }
        }

        private IniStatus status;

        /// <summary>
        /// Gets a value indicating whether there are unsaved changes.
        /// </summary>
        public IniStatus Status
        {
            get { return this.status; }
            protected set { this.status = value; }
        }

        private Dictionary<string, IniSection> sections;

        /// <summary>
        /// Gets all ini sections
        /// </summary>
        public List<IniSection> Sections
        {
            get { return this.sections.Values.ToList(); }
        }

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern int WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// Remove the entire section, according to the given argument
        /// </summary>
        public void Remove(string section)
        {
            if (this.sections[section] == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.sections[section].Remove();
            this.status = IniStatus.Modified;
        }

        /// <summary>
        /// Remove the section key, according to the given arguments
        /// </summary>
        public void Remove(string section, string key)
        {
            if (this.sections[section] == null || this.sections[section][key] == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.sections[section].Remove(key);
            this.status = IniStatus.Modified;
        }

        /// <summary>
        /// Insert a new section, without keys
        /// </summary>
        public void Insert(string section)
        {
            if (this.sections[section] != null)
            {
                throw new InvalidOperationException();
            }

            this.sections.Add(section, new IniSection(section));
            this.status = IniStatus.Modified;
        }

        /// <summary>
        /// Insert a new key value pair to a given section. If the section doesn't exist will be created.
        /// </summary>
        public void Insert(string section, string key, string value)
        {
            if (this.sections[section] == null)
            {
                this.sections.Add(section, new IniSection(section));
            }

            if (this.sections[section][key] != null)
            {
                throw new InvalidOperationException();
            }

            this.sections[section][key] = value;
            this.status = IniStatus.Modified;
        }

        /// <summary>
        /// Write/rewrite the instace file
        /// </summary>
        public void WriteToFile()
        {
            if (this.status == IniStatus.Unchanged)
            {
                return;
            }

            foreach (KeyValuePair<string, IniSection> section in this.sections)
            {
                if (section.Value.Status == IniStatus.Removed)
                {
                    //This will delete the section
                    WritePrivateProfileString(section.Key, null, null, FilePath);
                    continue;
                }

                foreach (IniKeyValuePair keyValue in section.Value.KeyValuePairs)
                {
                    if (keyValue.Status == IniStatus.Removed)
                    {
                        //This will delete the paramater
                        WritePrivateProfileString(section.Key, keyValue.Key, null, FilePath);
                        continue;
                    }

                    WritePrivateProfileString(section.Key, keyValue.Key, keyValue.Value, FilePath);
                }
            }

            this.status = IniStatus.Unchanged;
        }

        /// <summary>
        /// Gets the initilization file content.
        /// </summary>
        protected void GetProfileString()
        {
            this.sections = new Dictionary<string, IniSection>(StringComparer.CurrentCultureIgnoreCase);

            string currentSection = String.Empty;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    string fileLine = sr.ReadLine();

                    if (!String.IsNullOrEmpty(fileLine) && !String.IsNullOrWhiteSpace(fileLine))
                    {
                        if (fileLine.Trim().StartsWith("["))
                        {
                            currentSection = fileLine.Substring(1, fileLine.Length - 2);
                            this.sections.Add(currentSection, new IniSection(currentSection));
                        }
                        else
                        {
                            string[] keyValue = fileLine.Split('=');
                            this.sections[currentSection].Add(keyValue[0], keyValue[1]);
                        }
                    }
                }
            }
        }
    }
}