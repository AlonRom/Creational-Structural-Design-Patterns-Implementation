using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    class FriendLayoutPanel : ILayoutPanel
    {
        public async Task<TableLayoutPanel> GetLayoutAsync(User loggedInUser)
        {
            IFriendService friendService = new FriendService();
            List<FriendModel> userFriends = await friendService.GetUserFriendsAsync(loggedInUser);

            TableLayoutPanel m_Panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true };
            m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            m_Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

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
                        m_Panel.Controls.Add(new PictureBox { ImageLocation = propertyForDisplay.Value }, k_ImageColumnIndex, tempRowIndex);
                    }
                    else
                    {
                        m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = propertyForDisplay.Value }, k_DetailsColumnIndex, tempRowIndex);
                    }
                }
                tempRowIndex++;
            }
            return m_Panel;
        }
    }
}
