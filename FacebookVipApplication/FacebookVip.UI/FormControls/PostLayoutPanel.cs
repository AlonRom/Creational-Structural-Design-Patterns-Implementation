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
        private int m_NumSelectedItems;

        public PostLayoutPanel()
        {
            m_NumSelectedItems = 0;
            UsersListBox = new ListBox();
        }

        public async Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser)
        {
            m_Panel = new TableLayoutPanel { ColumnCount = 1, AutoScroll = true, AutoSize = true };

            IPostService postService = new PostService();
            List<PostModel> userPosts = await postService.GetUserPostsAsync(i_LoggedInUser);

            int tempRowIndex = 0;

            #region test list
            
            UsersListBox.SelectionMode = SelectionMode.MultiExtended;
            UsersListBox.Width = 150;
            UsersListBox.Margin = new Padding(50, 20, 20, 20);

            foreach (var user in i_LoggedInUser.Friends)
            {
                //var posts = user.Posts;
                UsersListBox.Items.Add(user);
            }
            m_Panel.Controls.Add(UsersListBox);
            UsersListBox.SelectedIndexChanged += personSelectedAsync;
            
            #endregion

            #region UserPosts
            m_Panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            m_Panel.Padding = new Padding(20, 0, 20, 0);
            foreach (PostModel post in userPosts)
            {
                m_Panel.Controls.Add(new PostControl(post, 0, tempRowIndex));

                tempRowIndex++;
            }
            #endregion

            return m_Panel;
        }

        private async void personSelectedAsync(object i_Sender, EventArgs i_EventArgs)
        {

            ListBox list = (ListBox)i_Sender;
            User selectedUser = (User)list.SelectedItem;
            int currentlySelected = list.SelectedItems.Count;

            if (currentlySelected > m_NumSelectedItems) {
                // add user data.
                PostService postService = new PostService();

                List<PostModel> userPosts = await postService.GetUserPostsAsync(selectedUser);
                foreach (PostModel post in userPosts)
                {
                    m_Panel.Controls.Add(new PostControl(post));
                }
            }
            else
            {
                // remove user from table
                m_Panel.Controls.RemoveByKey(selectedUser.Name);
            }
            m_NumSelectedItems = currentlySelected;       
        }

    }
}
