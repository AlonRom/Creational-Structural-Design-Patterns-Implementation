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
    class ProfileLayoutPanel : ILayoutPanel
    {
        public async Task<TableLayoutPanel> GetLayoutAsync(User loggedInUser)
        {
            IProfileService profileService = new ProfileService();
            ProfileModel userPorfile = await profileService.GetUserProfileAsync(loggedInUser);

            TableLayoutPanel m_Panel = new TableLayoutPanel { ColumnCount = 2 };
            m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            m_Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

            int tempRowIndex = 0;
            const int k_PropertyColumnIndex = 0;
            const int k_DetailsColumnIndex = 1;

            foreach (KeyValuePair<string, string> propertyForDisplay in userPorfile.GetPropertiesForDisplay())
            {
                m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12, FontStyle.Bold), Text = propertyForDisplay.Key }, k_PropertyColumnIndex, tempRowIndex);
                m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = propertyForDisplay.Value }, k_DetailsColumnIndex, tempRowIndex);
                tempRowIndex++;
            }
            return m_Panel;
        }
    }
}
