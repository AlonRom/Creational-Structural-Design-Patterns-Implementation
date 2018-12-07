using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookVip.UI.Properties;
using FacebookVip.UI.Utils;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    internal class ProfileLayoutPanel : ILayoutPanel
    {
        private readonly AppConfigService r_AppConfigService = AppConfigService.GetInstance();

        public async Task<TableLayoutPanel> GetLayoutPanelAsync(User i_LoggedInUser)
        {
            IProfileService profileService = new ProfileService();
            ProfileModel userPorfile = await profileService.GetUserProfileAsync(i_LoggedInUser);

            TableLayoutPanel panel = createProfilePanel(userPorfile);

            Button compareButton = new Button
            {
                Text = Resources.PostLayoutPanel_PostLayoutPanel_Compare,
            };
            compareButton.Click += (i_Sender, i_Args) => cloneProfilePanel(userPorfile);
            panel.Controls.Add(compareButton);

            return panel;
        }

        private TableLayoutPanel createProfilePanel(ProfileModel i_UserPorfile)
        {
            TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoSize = true, Padding = new Padding(10) };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

            int tempRowIndex = 0;
            const int k_PropertyColumnIndex = 0;
            const int k_DetailsColumnIndex = 1;

            foreach (KeyValuePair<string, string> propertyForDisplay in i_UserPorfile.GetPropertiesForDisplay())
            {
                panel.Controls.Add(
                    new Label
                    {
                        Font = new Font(AppUtil.sr_FontFamily, r_AppConfigService.LabelFontSize, FontStyle.Bold),
                        Text = propertyForDisplay.Key,
                        AutoSize = true
                    },
                    k_PropertyColumnIndex,
                    tempRowIndex);

                panel.Controls.Add(
                    new Label
                    {
                        Font = new Font(AppUtil.sr_FontFamily, r_AppConfigService.LabelFontSize),
                        Text = propertyForDisplay.Value,
                        AutoSize = true
                    },
                    k_DetailsColumnIndex,
                    tempRowIndex);

                tempRowIndex++;
            }
            return panel;
        }

        private void cloneProfilePanel(ProfileModel i_UserPorfile)
        {
            ProfileModel clonedProfile = i_UserPorfile.DeepClone();
            TableLayoutPanel panel = createProfilePanel(clonedProfile);
            Form profileForm = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                AutoSize = true,
                Icon = Resources.app_logo,
                Text = Resources.ProfileLayoutPanel_cloneProfilePanel_Cloned_Profile
            };
  
            profileForm.Controls.Add(panel);
            profileForm.Show();
        }
    }
}
