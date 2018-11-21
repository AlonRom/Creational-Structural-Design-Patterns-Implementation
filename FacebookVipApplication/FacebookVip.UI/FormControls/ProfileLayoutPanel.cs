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
        public async Task<TableLayoutPanel> GetLayoutPanelAsync(User i_LoggedInUser)
        {
            AppConfigService appConfigService = AppConfigService.GetInstance();
            IProfileService profileService = new ProfileService();
            ProfileModel userPorfile = await profileService.GetUserProfileAsync(i_LoggedInUser);

            TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoSize = true, Padding = new Padding(10) };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

            int tempRowIndex = 0;
            const int k_PropertyColumnIndex = 0;
            const int k_DetailsColumnIndex = 1;

            foreach (KeyValuePair<string, string> propertyForDisplay in userPorfile.GetPropertiesForDisplay())
            {
                panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, appConfigService.LabelFontSize, FontStyle.Bold), Text = propertyForDisplay.Key, AutoSize = true }, k_PropertyColumnIndex, tempRowIndex);
                panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, appConfigService.LabelFontSize), Text = propertyForDisplay.Value, AutoSize = true }, k_DetailsColumnIndex, tempRowIndex);
                tempRowIndex++;
            }
            return panel;
        }
    }
}
