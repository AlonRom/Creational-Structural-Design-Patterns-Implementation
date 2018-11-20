using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    public class PostLayoutPanel : ILayoutPanel
    {
        private ListBox UsersListBox { get; set; }
        private TableLayoutPanel m_Panel;
        private TableLayoutPanel m_PostsPanel;

        private int m_NumSelectedItems;
        private int m_RowIndex;
        private System.Windows.Forms.PictureBox Spinner;

        public PostLayoutPanel()
        {
            m_NumSelectedItems = 0;
            UsersListBox = new ListBox
            {
                SelectionMode = SelectionMode.MultiExtended,
                Width = 150,
                Margin = new Padding(50, 20, 20, 20)
            };

            m_PostsPanel = new TableLayoutPanel {
                ColumnCount = 1,
                AutoScroll = true,
                Height = 300,
                Width = 350,
                Dock = DockStyle.Fill
            };

            m_Panel = new TableLayoutPanel
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
            Label commentLabel = new Label { Text = "* Select Friend whose POSTs you like to see - using Ctrl button", AutoSize = true };
            
            UsersListBox.Items.Add(i_LoggedInUser);
            foreach (var user in i_LoggedInUser.Friends)
            {
                UsersListBox.Items.Add(user);
            }
            m_Panel.Controls.Add(commentLabel);
            m_Panel.Controls.Add(UsersListBox);
            UsersListBox.SelectedIndexChanged += personSelectedAsync;

            UsersListBox.SelectedIndex=0;
            personSelectedAsync(null, null);
            m_Panel.Controls.Add(m_PostsPanel);

            return m_Panel;
        }

        
        private void addUsersPosts(List<PostModel> userPosts)
        {
            foreach (PostModel post in userPosts)
            {
                m_PostsPanel.Controls.Add(new PostControl(post, 0, m_RowIndex));
                m_RowIndex++;
            }
        }

        /*
        private async void personSelectedAsync(object i_Sender, EventArgs i_EventArgs)
        {

            ListBox list = (ListBox)i_Sender;
            User selectedUser = (User)list.SelectedItem;
            int currentlySelected = list.SelectedItems.Count;

            if (currentlySelected > m_NumSelectedItems) {
                // add user data.
                PostService postService = new PostService();
                List<PostModel> userPosts = await postService.GetUserPostsAsync(selectedUser);
                
                if (userPosts.Count == 0) userPosts = postService.GetUserPostsMockData(selectedUser);
                
                addUsersPosts(userPosts);
            }
            else
            {
                // remove user from table
                m_Panel.Controls.RemoveByKey(selectedUser.Name);
            }
            m_NumSelectedItems = currentlySelected;       
        }
        */

        private async void personSelectedAsync(object i_Sender, EventArgs i_EventArgs)
        {
            Cursor.Current = Cursors.WaitCursor;
            UsersListBox.Enabled = false;
            PostService postService = new PostService();

            m_PostsPanel.Controls.Clear();

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
