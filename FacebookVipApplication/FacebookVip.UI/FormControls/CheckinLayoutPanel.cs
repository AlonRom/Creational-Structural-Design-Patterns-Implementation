using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.UI.Utils;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    internal class CheckinLayoutPanel : ILayoutPanel
    {
        private TableLayoutPanel m_Panel;

        public async Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser)
        {
            ICheckinService checkinService = new CheckinService();
            List<Checkin> userCheckins = await checkinService.GetUserCheckinsAsync(i_LoggedInUser);

            m_Panel = new TableLayoutPanel
            {
                ColumnCount = 1,
                AutoScroll = true,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Padding = new Padding(10, 0, 10, 0)
            };


            foreach (Checkin checkinItem in userCheckins)
            {
                m_Panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, AppConfigService.GetInstance().LabelFontSize, FontStyle.Bold), Text = checkinItem.Place.Name });
            }

            return m_Panel;
        }
    }
}
