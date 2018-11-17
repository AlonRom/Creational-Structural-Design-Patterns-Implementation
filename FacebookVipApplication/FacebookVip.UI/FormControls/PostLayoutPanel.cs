using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    public class PostLayoutPanel : ILayoutPanel
    {
        private Font TextFont{ get; set; }
        private ListBox usersListBox { get; set; }
        private TableLayoutPanel m_Panel;
        private int numSelectedItems;

        public PostLayoutPanel() {
            numSelectedItems = 0;
            usersListBox = new ListBox();
        }

        public async Task<TableLayoutPanel> GetLayoutAsync(User LoggedInUser) {
            m_Panel = new TableLayoutPanel { ColumnCount = 1, AutoScroll = true, AutoSize = true };

            IPostService postService = new PostService();
            List<PostModel> userPosts = await postService.GetUserPostsAsync(LoggedInUser);

            int tempRowIndex = 0;

            #region test list
            
            usersListBox.SelectionMode = SelectionMode.MultiExtended;
            usersListBox.Width = 150;
            usersListBox.Margin = new Padding(50, 20, 20, 20);

            foreach (var user in LoggedInUser.Friends)
            {
                //var posts = user.Posts;
                usersListBox.Items.Add(user);
            }
            m_Panel.Controls.Add(usersListBox);
            usersListBox.SelectedIndexChanged += personSelectedAsync;
            
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

            if (currentlySelected > this.numSelectedItems) {
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
            this.numSelectedItems = currentlySelected;



            
        }

    }
}
