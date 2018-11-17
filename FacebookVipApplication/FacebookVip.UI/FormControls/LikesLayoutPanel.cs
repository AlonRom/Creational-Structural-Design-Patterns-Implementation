using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    internal class LikesLayoutPanel : ILayoutPanel
    {
        public async Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser)
        {
            ILikeService likeService = new LikesService(i_LoggedInUser);
            ObservableCollection<PostedItem> items = new ObservableCollection<PostedItem>(i_LoggedInUser.PhotosTaggedIn);
            Dictionary<string, int> userLikesPhotos = await likeService.GetLikesHistogram(items);

            items = new ObservableCollection<PostedItem>(i_LoggedInUser.Posts);
            Dictionary<string, int> userLikesPosts = await likeService.GetLikesHistogram(items);

            items = new ObservableCollection<PostedItem>(i_LoggedInUser.Albums);
            Dictionary<string, int> userLikesAlbums = await likeService.GetLikesHistogram(items);

            TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 3, AutoScroll = true };
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 40F));

            Font labelFont = new Font("Arial", 12);
            Font titleFont = new Font("Arial", 20);

            fillLikeToTable("Photos", userLikesPhotos, panel, labelFont, titleFont, 0, 0);
            fillLikeToTable("Posts", userLikesPosts, panel, labelFont, titleFont, 0, 1);
            fillLikeToTable("Albums", userLikesAlbums, panel, labelFont, titleFont, 0, 2);

            return panel;
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
