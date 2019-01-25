using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookVip.UI.Properties;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    public interface IStrategyWriter
    {
        string Extention { get; }
        void Init();
        void WriteLine(String line);
        void Fini();
        IEnumerable<string> GetResult();
    }

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

    public class DotWriter : IStrategyWriter
    {
        private List<string> file_lines;
        public string Extention { get; }

        public DotWriter()
        {
            file_lines = new List<string>();
            Extention = "txt";
        }

        public void Fini(){}

        public IEnumerable<string> GetResult()
        {
            return file_lines;
        }

        public void Init(){}

        public void WriteLine(string line)
        {
            file_lines.Add("* " + line);
        }
    }

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
            foreach (PostModel post in i_UsersPosts) {
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

    public class PostLayoutPanel : ILayoutPanel
    {
        private ListBox UsersListBox { get; }
        private readonly TableLayoutPanel r_Panel;
        private readonly TableLayoutPanel r_PostsPanel;

        private int m_RowIndex;

        public PostLayoutPanel()
        {
            UsersListBox = new ListBox
            {
                SelectionMode = SelectionMode.MultiExtended,
                Width = 150,
                Margin = new Padding(50, 20, 20, 20)
            };

            r_PostsPanel = new TableLayoutPanel {
                ColumnCount = 1,
                AutoScroll = true,
                Height = 300,
                Width = 350,
                Dock = DockStyle.Fill
            };

            r_Panel = new TableLayoutPanel
            {
                ColumnCount = 1,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Padding = new Padding(20, 0, 20, 0),
                Dock = DockStyle.Fill
            };

        }

        public async Task<TableLayoutPanel> GetLayoutPanelAsync(User i_LoggedInUser)
        {
            IFriendService friendsService = new FriendService();
            var friendsList = await friendsService.GetFriendsAsync(i_LoggedInUser);
            Label commentLabel = new Label { Text = Resources.SelectFriendWhosePOSTsYouLikeToSee, AutoSize = true };
            
            UsersListBox.Items.Add(i_LoggedInUser);
            foreach (User user in friendsList)
            {
                UsersListBox.Items.Add(user);
            }
            r_Panel.Controls.Add(commentLabel);
            r_Panel.Controls.Add(UsersListBox);
            UsersListBox.SelectedIndexChanged += personSelectedAsync;

            UsersListBox.SelectedIndex=0;
            personSelectedAsync(null, null);
            r_Panel.Controls.Add(r_PostsPanel);

            return r_Panel; 
        }

        
        private void addUsersPosts(List<PostModel> i_UserPosts)
        {
            foreach (PostModel post in i_UserPosts)
            {
                r_PostsPanel.Controls.Add(new PostControl(post, 0, m_RowIndex));
                m_RowIndex++;
            }
        }

        private List<PostModel> userPosts;
        private async void personSelectedAsync(object i_Sender, EventArgs i_EventArgs)
        {
            Cursor.Current = Cursors.WaitCursor;
            UsersListBox.Enabled = false;
            PostService postService = new PostService();

            r_PostsPanel.Controls.Clear();

            foreach (User selectedUser in UsersListBox.SelectedItems)
            {
                // add user data.
                userPosts = await postService.GetUserPostsAsync(selectedUser);
                if (userPosts.Count == 0)
                {
                    userPosts = postService.GetUserPostsMockData(selectedUser);
                }

                addUsersPosts(userPosts);
            }
            UsersListBox.Enabled = true;
            Cursor.Current = Cursors.Arrow;

            writePostsToFile();
        }

        private void writePostsToFile()
        {
            FlieWriter html_file_writer = new FlieWriter(new HTMLWriter());
            FlieWriter dot_file_writer = new FlieWriter(new DotWriter());
            html_file_writer.WritePostsToFile(userPosts);
            dot_file_writer.WritePostsToFile(userPosts);
        }
    }

    
}
