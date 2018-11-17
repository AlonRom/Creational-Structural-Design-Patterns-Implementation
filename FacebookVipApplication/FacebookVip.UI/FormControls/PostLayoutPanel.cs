using System;
using System.Collections.Generic;
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

        public PostLayoutPanel()
        {
            m_NumSelectedItems = 0;
            UsersListBox = new ListBox();
            m_PostsPanel = new TableLayoutPanel {
                ColumnCount = 1,
                AutoScroll = true,
                AutoSize = true,
                Dock = DockStyle.Fill
            };

            m_Panel = new TableLayoutPanel
            {
                ColumnCount = 1,
                AutoScroll = true,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Padding = new Padding(20, 0, 20, 0),
                Dock = DockStyle.Fill
            };

        }

        public async Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser)
        {            
            IPostService postService = new PostService();
            List<PostModel> userPosts = await postService.GetUserPostsAsync(i_LoggedInUser);

            UsersListBox.SelectionMode = SelectionMode.MultiExtended;
            UsersListBox.Width = 150;
            UsersListBox.Margin = new Padding(50, 20, 20, 20);

            UsersListBox.Items.Add(i_LoggedInUser);
            foreach (var user in i_LoggedInUser.Friends)
            {
                //var posts = user.Posts;
                UsersListBox.Items.Add(user);
            }
            m_Panel.Controls.Add(UsersListBox);
            UsersListBox.SelectedIndexChanged += personSelectedAsync;


            //addUsersPosts(userPosts);
            //UsersListBox.SelectedIndex=0;
            //personSelectedAsync(null, null);
            m_Panel.Controls.Add(m_PostsPanel,0,1);

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
            PostService postService = new PostService();

            m_PostsPanel.Controls.Clear();

            foreach (User selectedUser in UsersListBox.SelectedItems) { 
                // add user data.
                List<PostModel> userPosts = await postService.GetUserPostsAsync(selectedUser);
                if (userPosts.Count == 0) userPosts = postService.GetUserPostsMockData(selectedUser);

                addUsersPosts(userPosts);
            }
        }
    }

    
}
