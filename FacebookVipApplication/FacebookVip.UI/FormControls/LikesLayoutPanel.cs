using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.UI.Utils;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    internal class LikesLayoutPanel : ILayoutPanel
    {
        private readonly AppConfigService r_AppConfigService = AppConfigService.GetInstance();

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

            fillLikeToTable("Photos", userLikesPhotos, panel, 0, 0);
            fillLikeToTable("Posts", userLikesPosts, panel, 0, 1);
            fillLikeToTable("Albums", userLikesAlbums, panel, 0, 2);

            return panel;
        }

        private void fillLikeToTable(string i_LableName, Dictionary<string, int> i_UserLikesPhotos, TableLayoutPanel i_Panel, int i_RowIndex, int i_ColumnIndex)
        {
            i_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 50F));
            i_Panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, r_AppConfigService.TitleFontSize, FontStyle.Bold), Text = i_LableName, AutoSize = true }, i_ColumnIndex, i_RowIndex);
            foreach (KeyValuePair<string, int> propertyForDisplay in i_UserLikesPhotos)
            {
                i_RowIndex++;
                i_Panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, r_AppConfigService.LabelFontSize), Text = propertyForDisplay.Key + @" " + propertyForDisplay.Value, AutoSize = true }, i_ColumnIndex, i_RowIndex);
            }
        }
    }
}
