using FacebookVip.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookVip.Logic.FileWriter
{
    public class DotWriter : IStrategyWriter
    {
        private List<string> file_lines;
        public string Extention { get; }

        public DotWriter()
        {
            file_lines = new List<string>();
            Extention = "txt";
        }

        public void Fini() { }

        public IEnumerable<string> GetResult()
        {
            return file_lines;
        }

        public void Init() { }

        public void WriteLine(string i_Line)
        {
            file_lines.Add("* " + i_Line);
        }
    }
}
