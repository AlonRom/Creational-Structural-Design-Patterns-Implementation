using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookVip.UI.Properties;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
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

        public async Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser)
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

        private async void personSelectedAsync(object i_Sender, EventArgs i_EventArgs)
        {
            Cursor.Current = Cursors.WaitCursor;
            UsersListBox.Enabled = false;
            PostService postService = new PostService();

            r_PostsPanel.Controls.Clear();

            foreach (User selectedUser in UsersListBox.SelectedItems) { 
                // add user data.
                List<PostModel> userPosts = await postService.GetUserPostsAsync(selectedUser);
                if (userPosts.Count == 0) userPosts = postService.GetUserPostsMockData(selectedUser);

                addUsersPosts(userPosts);
            }
            UsersListBox.Enabled = true;
            Cursor.Current = Cursors.Arrow;
        }
    }

    
}
