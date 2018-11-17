using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Enums;
using FacebookVip.UI.Properties;
using FacebookVip.UI.Utils;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    internal class SettingsLayoutPanel : ILayoutPanel
    {
        public Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser)
        {
            return Task.Run(() =>
            {
                AppConfigService appConfigService = AppConfigService.GetInstance();

                TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoSize = true, AutoScroll = true };
       
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int currentRow = 0;

                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 30F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 60F));

                //app panel
                panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, appConfigService.TitleFontSize, FontStyle.Bold), Text = Resources.ApplicationTitle, AutoSize = true, Padding = new Padding(0, 7, 7, 7) }, 0, currentRow);

                panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, appConfigService.LabelFontSize), Text = Resources.LabelFontSizeTitle, AutoSize = true, Padding = new Padding(5, 5, 5, 15) }, 0, ++currentRow);

                NumericUpDown labelFontSizeUpDown = new NumericUpDown
                {
                    Text = appConfigService.LabelFontSize.ToString(),
                    Minimum = 10,
                    Maximum = 16
                };

                labelFontSizeUpDown.TextChanged += delegate
                {
                    int value;
                    if (int.TryParse(labelFontSizeUpDown.Text, out value))
                    {
                        appConfigService.LabelFontSize = value;
                    }
                };
                panel.Controls.Add(labelFontSizeUpDown, 1, currentRow);

                panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, appConfigService.LabelFontSize), Text = Resources.TitleFontSizeTitle, AutoSize = true, Padding = new Padding(5, 5, 5, 15) }, 0, ++currentRow);

                NumericUpDown titleFontSizeUpDown = new NumericUpDown
                {
                    Text = appConfigService.TitleFontSize.ToString(),
                    Minimum = 18,
                    Maximum = 24
                };

                titleFontSizeUpDown.TextChanged += delegate
                {
                    int value;
                    if (int.TryParse(titleFontSizeUpDown.Text, out value))
                    {
                        appConfigService.TitleFontSize = value;
                    }
                };
                panel.Controls.Add(titleFontSizeUpDown, 1, currentRow);

                //stats panel
                panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, appConfigService.TitleFontSize, FontStyle.Bold), Text = Resources.StatsTitle, AutoSize = true, Padding = new Padding(0, 14, 7, 7) }, 0, ++currentRow);
                panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, appConfigService.LabelFontSize), Text = Resources.ChartTypeTitle, AutoSize = true, Padding = new Padding(5) }, 0, ++currentRow);

                FlowLayoutPanel chartTypePanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
                RadioButton columnChartRadioButton = new RadioButton
                {
                    Text = SeriesChartType.Column.ToString(),
                    Checked = appConfigService.StateSettings.SelectedChartType == SeriesChartType.Column
                };
                columnChartRadioButton.CheckedChanged += delegate
                {
                    appConfigService.StateSettings.SelectedChartType = SeriesChartType.Column;
                };

                RadioButton pieChartRadioButton = new RadioButton
                {
                    Text = SeriesChartType.Pie.ToString(),
                    Checked = appConfigService.StateSettings.SelectedChartType == SeriesChartType.Pie
                };

                pieChartRadioButton.CheckedChanged += delegate
                {
                    appConfigService.StateSettings.SelectedChartType = SeriesChartType.Pie;
                };

                chartTypePanel.Controls.Add(columnChartRadioButton);
                chartTypePanel.Controls.Add(pieChartRadioButton);
                panel.Controls.Add(chartTypePanel, 1, currentRow);

                panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, appConfigService.LabelFontSize), Text = Resources.NumberOfFriendsToConsiderTitle, AutoSize = true, Padding = new Padding(5, 5, 5, 15) }, 0, ++currentRow);

                NumericUpDown numberOfFriendUpDown = new NumericUpDown
                {
                    Text = appConfigService.StateSettings.NumberOfFriend.ToString(),
                    Minimum = 1,
                    Maximum = 9,
                };

                numberOfFriendUpDown.TextChanged += delegate
                {
                    int value;
                    if (int.TryParse(numberOfFriendUpDown.Text, out value))
                    {
                        appConfigService.StateSettings.NumberOfFriend = value;
                    }
                };
                panel.Controls.Add(numberOfFriendUpDown, 1, currentRow);

                panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, appConfigService.LabelFontSize), Text = Resources.CollectDataFromTitle, AutoSize = true, Padding = new Padding(5) }, 0, ++currentRow);
                FlowLayoutPanel likedItemsPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
                foreach (eLikedItem likedItem in Enum.GetValues(typeof(eLikedItem)))
                {
                    CheckBox checkBox = new CheckBox { Text = likedItem.GetPropertyForDisplay(), Checked = appConfigService.StateSettings.LikedItems[likedItem] };
                    checkBox.CheckedChanged += delegate (object i_S, EventArgs i_E)
                    {
                        appConfigService.StateSettings.LikedItems[likedItem] = ((CheckBox)i_S).Checked;
                    };
                    likedItemsPanel.Controls.Add(checkBox);
                }
                panel.Controls.Add(likedItemsPanel, 1, currentRow);

                return panel;
            });
        }
    }
}
