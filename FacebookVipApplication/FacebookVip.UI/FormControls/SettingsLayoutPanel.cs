using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Enums;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    class SettingsLayoutPanel : ILayoutPanel
    {
        public Task<TableLayoutPanel> GetLayoutAsync(User loggedInUser)
        {
            return Task.Run(() =>
            { 
            #region makePanel
            TableLayoutPanel m_Panel = new TableLayoutPanel { ColumnCount = 2, AutoSize = true, AutoScroll = true };
            m_Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

            int currentRow = 0;

            m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 30F));
            m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 60F));
            m_Panel.Controls.Add(new Label { Font = new Font("Arial", 20, FontStyle.Bold), Text = @"Stats", AutoSize = true, Padding = new Padding(0, 7, 7, 7) }, 0, currentRow);
            m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = @"Chart Type:", AutoSize = true, Padding = new Padding(5) }, 0, ++currentRow);

            FlowLayoutPanel chartTypePanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
            RadioButton columnChartRadioButton = new RadioButton
            {
                Text = SeriesChartType.Column.ToString(),
                Checked = AppAppConfigService.GetInstance().StateSettings.SelectedChartType == SeriesChartType.Column
            };
            columnChartRadioButton.CheckedChanged += delegate
            {
                AppAppConfigService.GetInstance().StateSettings.SelectedChartType = SeriesChartType.Column;
            };

            RadioButton pieChartRadioButton = new RadioButton
            {
                Text = SeriesChartType.Pie.ToString(),
                Checked = AppAppConfigService.GetInstance().StateSettings.SelectedChartType == SeriesChartType.Pie
            };

            pieChartRadioButton.CheckedChanged += delegate
            {
                AppAppConfigService.GetInstance().StateSettings.SelectedChartType = SeriesChartType.Pie;
            };

            chartTypePanel.Controls.Add(columnChartRadioButton);
            chartTypePanel.Controls.Add(pieChartRadioButton);
            m_Panel.Controls.Add(chartTypePanel, 1, currentRow);

            m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = @"Number Of Friends To Consider:", AutoSize = true, Padding = new Padding(5, 5, 5, 15) }, 0, ++currentRow);

            TextBox numberOfFriendsTextBox = new TextBox { Text = AppAppConfigService.GetInstance().StateSettings.NumberOfFriend.ToString() };
            numberOfFriendsTextBox.TextChanged += delegate
            {
                int value;
                if (int.TryParse(numberOfFriendsTextBox.Text, out value))
                {
                    AppAppConfigService.GetInstance().StateSettings.NumberOfFriend = value;
                }
            };
            numberOfFriendsTextBox.KeyPress += delegate (object i_S, KeyPressEventArgs i_E)
            {
                char ch = i_E.KeyChar;
                if (!ch.IsDigid())
                {
                    i_E.Handled = true;
                }
            };
            m_Panel.Controls.Add(numberOfFriendsTextBox, 1, currentRow);

            m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = @"Collect Data From:", AutoSize = true, Padding = new Padding(5) }, 0, ++currentRow);
            FlowLayoutPanel likedItemsPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
            foreach (eLikedItem likedItem in Enum.GetValues(typeof(eLikedItem)))
            {
                CheckBox checkBox = new CheckBox { Text = likedItem.GetPropertyForDisplay(), Checked = AppAppConfigService.GetInstance().StateSettings.LikedItems[likedItem] };
                checkBox.CheckedChanged += delegate (object i_S, EventArgs i_E)
                {
                    AppAppConfigService.GetInstance().StateSettings.LikedItems[likedItem] = ((CheckBox)i_S).Checked;
                };
                likedItemsPanel.Controls.Add(checkBox);
            }
            m_Panel.Controls.Add(likedItemsPanel, 1, currentRow);

            return m_Panel;
                #endregion
            });
        }
    }
}
