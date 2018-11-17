using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    class LikesLayoutPanel : ILayoutPanel
    {

        public async Task<TableLayoutPanel> GetLayoutAsync(User loggedInUser)
        {
            ILikeService likeService = new LikesService(loggedInUser);
            ObservableCollection<PostedItem> items = new ObservableCollection<PostedItem>(loggedInUser.PhotosTaggedIn);
            Dictionary<string, int> userLikesPhotos = await likeService.GetLikesHistogram(items);

            items = new ObservableCollection<PostedItem>(loggedInUser.Posts);
            Dictionary<string, int> userLikesPosts = await likeService.GetLikesHistogram(items);

            items = new ObservableCollection<PostedItem>(loggedInUser.Albums);
            Dictionary<string, int> userLikesAlbums = await likeService.GetLikesHistogram(items);

            TableLayoutPanel m_Panel = new TableLayoutPanel { ColumnCount = 3, AutoScroll = true };
            m_Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 40F));

            Font labelFont = new Font("Arial", 12);
            Font titleFont = new Font("Arial", 20);

            fillLikeToTable("Photos", userLikesPhotos, m_Panel, labelFont, titleFont, 0, 0);
            fillLikeToTable("Posts", userLikesPosts, m_Panel, labelFont, titleFont, 0, 1);
            fillLikeToTable("Albums", userLikesAlbums, m_Panel, labelFont, titleFont, 0, 2);

            return m_Panel;
        }

        private void fillLikeToTable(string i_LableName, Dictionary<string, int> i_UserLikesPhotos, TableLayoutPanel i_Panel, Font i_LabelFont, Font i_TitleFont, int i_RowIndex, int i_ColumnIndex)
        {
            i_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 50F));
            i_Panel.Controls.Add(new Label { Font = i_TitleFont, Text = i_LableName, AutoSize = true }, i_ColumnIndex, i_RowIndex);
            foreach (KeyValuePair<string, int> propertyForDisplay in i_UserLikesPhotos)
            {
                i_RowIndex++;
                i_Panel.Controls.Add(new Label { Font = i_LabelFont, Text = propertyForDisplay.Key + @" " + propertyForDisplay.Value, AutoSize = true }, i_ColumnIndex, i_RowIndex);
            }
        }


    }
}
