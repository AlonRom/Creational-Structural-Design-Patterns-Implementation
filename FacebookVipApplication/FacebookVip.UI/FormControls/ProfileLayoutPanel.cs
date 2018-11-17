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
    internal class ProfileLayoutPanel : ILayoutPanel
    {
        public async Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser)
        {
            IProfileService profileService = new ProfileService();
            ProfileModel userPorfile = await profileService.GetUserProfileAsync(i_LoggedInUser);

            TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2 };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

            int tempRowIndex = 0;
            const int k_PropertyColumnIndex = 0;
            const int k_DetailsColumnIndex = 1;

            foreach (KeyValuePair<string, string> propertyForDisplay in userPorfile.GetPropertiesForDisplay())
            {
                panel.Controls.Add(new Label { Font = AppUtil.sr_LabelFontBold, Text = propertyForDisplay.Key }, k_PropertyColumnIndex, tempRowIndex);
                panel.Controls.Add(new Label { Font = AppUtil.sr_LabelFont, Text = propertyForDisplay.Value }, k_DetailsColumnIndex, tempRowIndex);
                tempRowIndex++;
            }
            return panel;
        }
    }
}
