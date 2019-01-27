using FacebookVip.Logic.Interfaces;
using FacebookVip.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookVip.Logic.FileWriter
{
    public class FlieWriter
    {
        private IStrategyWriter strategy_writer;

        public FlieWriter(IStrategyWriter i_StrategyWriter)
        {
            strategy_writer = i_StrategyWriter;
        }

        private IEnumerable<string> PrepareData(List<PostModel> i_UsersPosts)
        {
            strategy_writer.Init();
            foreach (PostModel post in i_UsersPosts)
            {
                strategy_writer.WriteLine(post.ToString());
            }
            strategy_writer.Fini();

            return strategy_writer.GetResult();
        }

        private void export(string i_DocPath, IEnumerable<string> i_Lines)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(i_DocPath, "WriteLines." + strategy_writer.Extention)))
            {
                foreach (string line in i_Lines)
                    outputFile.WriteLine(line);
            }
        }

        public void WritePostsToFile(List<PostModel> i_UsersPosts)
        {
            IEnumerable<string> lines = PrepareData(i_UsersPosts);

            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            export(docPath, lines);
        }

    }
}
