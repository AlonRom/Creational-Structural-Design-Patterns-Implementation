using FacebookVip.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookVip.Model.FileWriter
{
    public class HTMLWriter : IStrategyWriter
    {
        private List<string> file_lines;

        public string Extention { get; }

        public HTMLWriter()
        {
            Extention = "html";
            file_lines = new List<string>();
        }

        public void Init()
        {
            file_lines.Add("<HTML>");
            file_lines.Add("<HEAD> <TITLE> Posts </TITLE> </HEAD>");
            file_lines.Add("<BODY>");
            file_lines.Add("<H1> Posts: </H1>");
            file_lines.Add("<ul>");
        }

        public void Fini()
        {
            file_lines.Add("</ul>");
            file_lines.Add("</BODY>");
            file_lines.Add("</HTML>");
        }

        public void WriteLine(string i_Line)
        {
            file_lines.Add("<li>" + i_Line + "</li>");
        }

        public IEnumerable<string> GetResult()
        {
            return file_lines;
        }
    }
}
