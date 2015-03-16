using Bymyslf.IniFileParser;
using Bymyslf.IniFileParser.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bymyslf.IniFileParser.Demo
{
    internal class Program
    {
        private const string RESOURCE_NAME = "test.ini";

        private static void PrintFile()
        {
            using (var reader = new StreamReader(RESOURCE_NAME))
            {
                while (reader.Peek() >= 0)
                {
                    string fileLine = reader.ReadLine();
                    Console.WriteLine(fileLine);
                }
            }
        }

        private static void Main(string[] args)
        {
            PrintFile();

            var sr = new IniFileStreamReader(RESOURCE_NAME);
            var iniFile = sr.Read();

            iniFile.Sections["owner"].Keys["name"].Value = "Test Owner";
            iniFile.Sections.AddSection("test section");
            iniFile.Sections["test section"].Comments.Add("Test comment");
            iniFile.Sections["test section"].Keys.AddKey("test key", "key value");

            Console.WriteLine();
            Console.WriteLine("----- After Changes -----");
            Console.WriteLine();

            var sw = new IniFileStreamWriter(RESOURCE_NAME);
            sw.Write(iniFile);

            PrintFile();

            Console.ReadKey();
        }
    }
}