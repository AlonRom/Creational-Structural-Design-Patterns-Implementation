using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookVip.UI.Utils;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    internal class FriendLayoutPanel : ILayoutPanel
    {
        public async Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser)
        {
            IFriendService friendService = new FriendService();
            List<FriendModel> userFriends = await friendService.GetUserFriendsAsync(i_LoggedInUser);

            TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true, Padding = new Padding(10)};
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

            int tempRowIndex = 0;
            const int k_ImageColumnIndex = 0;
            const int k_DetailsColumnIndex = 1;

            foreach (FriendModel friend in userFriends)
            {
                foreach (KeyValuePair<string, string> propertyForDisplay in friend.GetPropertiesForDisplay())
                {
                    Uri uriResult;
                    bool isImageUrl = Uri.TryCreate(propertyForDisplay.Value, UriKind.Absolute, out uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                    if (isImageUrl)
                    {
                        panel.Controls.Add(new PictureBox { ImageLocation = propertyForDisplay.Value }, k_ImageColumnIndex, tempRowIndex);
                    }
                    else
                    {
                        panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, AppConfigService.GetInstance().LabelFontSize), Text = propertyForDisplay.Value }, k_DetailsColumnIndex, tempRowIndex);
                    }
                }
                tempRowIndex++;
            }
            return panel;
        }
    }
}
