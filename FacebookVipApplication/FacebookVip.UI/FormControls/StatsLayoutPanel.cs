using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Enums;
using FacebookVip.Model.Models;
using FacebookVip.UI.Properties;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    internal class StatsLayoutPanel : ILayoutPanel
    {
        public async Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser)
        {
            StateSettings appConfigServiceStateSettings = AppConfigService.GetInstance().StateSettings;
            TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 1, AutoScroll = true };
            ILikeService likeService = new LikesService(i_LoggedInUser);

            // get data as defined in settings
            List<Task> getDataTasks = new List<Task>();
            Dictionary<string, int> allPostemItemsLikes = new Dictionary<string, int>();
            foreach(KeyValuePair<eLikedItem, bool> keyValuePair in appConfigServiceStateSettings.LikedItems.Where(i_Item => i_Item.Value))
            {
                Task getDataTask = Task.Run(
                    async () =>
                        {
                            PropertyInfo propertyInfo = i_LoggedInUser.GetType()
                                .GetProperty(keyValuePair.Key.ToString());
                            if(propertyInfo != null)
                            {
                                try
                                {
                                    object prop = propertyInfo.GetValue(i_LoggedInUser, null);
                                    IEnumerable collectionOfUnknownType = (IEnumerable)prop;
                                    ObservableCollection<PostedItem> currentPostedItems =
                                        new ObservableCollection<PostedItem>();
                                    foreach(PostedItem o in collectionOfUnknownType)
                                    {
                                        currentPostedItems.Add(o);
                                    }

                                    Dictionary<string, int> currenLikes =
                                        await likeService.GetLikesHistogram(currentPostedItems).ConfigureAwait(false);
                                    allPostemItemsLikes.AddRange<string, int>(currenLikes);

                                }
                                catch(Exception)
                                {
                                    Console.WriteLine(Resources.FailedToRretrieveDataLikesForErrorMessage + propertyInfo);
                                }
                            }
                        });
                getDataTasks.Add(getDataTask);
            }

            await Task.WhenAll(getDataTasks);

            Chart likeMeTheMostChart = new Chart();
            Chart likeMeTheLeastChart = new Chart();
            ((ISupportInitialize)likeMeTheMostChart).BeginInit();
            ((ISupportInitialize)likeMeTheLeastChart).BeginInit();

            ChartArea chartsArea = new ChartArea();
            likeMeTheMostChart.ChartAreas.Add(chartsArea);
            likeMeTheMostChart.Dock = DockStyle.Top;

            if(appConfigServiceStateSettings.SelectedChartType == SeriesChartType.Pie)
            {
                Legend likeMeTheMostLegend = new Legend { BackColor = Color.White, ForeColor = Color.Black};
                Legend likeMeTheLeastLegend = new Legend { BackColor = Color.White, ForeColor = Color.Black };

                likeMeTheMostChart.Legends.Add(likeMeTheMostLegend);
                likeMeTheLeastChart.Legends.Add(likeMeTheLeastLegend);
            }

            Title title = likeMeTheMostChart.Titles.Add("Who Likes me the most!");
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            title.Alignment = ContentAlignment.TopCenter;

            likeMeTheMostChart.Series.Clear();
            likeMeTheMostChart.Palette = ChartColorPalette.Fire;
            likeMeTheMostChart.ChartAreas[0].BackColor = Color.Transparent;
            likeMeTheMostChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            likeMeTheMostChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Series series = new Series
                                {
                                    IsVisibleInLegend = true,
                                    ChartType = appConfigServiceStateSettings.SelectedChartType
                                };
            likeMeTheMostChart.Series.Add(series);

            int i = 0;
            Random rnd = new Random();
            foreach(
                KeyValuePair<string, int> userLikesPhoto in
                allPostemItemsLikes.OrderByDescending(i_L => i_L.Value)
                    .Take(appConfigServiceStateSettings.NumberOfFriend))
            {
                series.Points.Add(userLikesPhoto.Value);
                DataPoint dataPoint = series.Points[i];
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                dataPoint.Color = randomColor;
                dataPoint.AxisLabel = userLikesPhoto.Key;
                dataPoint.LegendText = userLikesPhoto.Key;
                dataPoint.Label = userLikesPhoto.Value.ToString();
                i++;
            }
            likeMeTheMostChart.Invalidate();

            ChartArea chartsArea2 = new ChartArea();
            likeMeTheLeastChart.ChartAreas.Add(chartsArea2);
            likeMeTheLeastChart.Dock = DockStyle.Bottom;

            Title likeMeTheLeastChartTitle = likeMeTheLeastChart.Titles.Add("Who Likes me the least!");
            likeMeTheLeastChartTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            title.Alignment = ContentAlignment.TopCenter;

            likeMeTheLeastChart.Series.Clear();
            likeMeTheLeastChart.Palette = ChartColorPalette.Fire;
            likeMeTheLeastChart.ChartAreas[0].BackColor = Color.Transparent;
            likeMeTheLeastChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            likeMeTheLeastChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Series series2 = new Series
                                 {
                                     IsVisibleInLegend = true,
                                     ChartType = appConfigServiceStateSettings.SelectedChartType
                                 };
            likeMeTheLeastChart.Series.Add(series2);

            i = 0;
            foreach(KeyValuePair<string, int> userLikesPhoto in allPostemItemsLikes.OrderBy(i_L => i_L.Value)
                                                            .Take(appConfigServiceStateSettings.NumberOfFriend))
            {
                series2.Points.Add(userLikesPhoto.Value);
                DataPoint dataPoint = series2.Points[i];
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                dataPoint.Color = randomColor;
                dataPoint.AxisLabel = userLikesPhoto.Key;
                dataPoint.LegendText = userLikesPhoto.Key;
                dataPoint.Label = userLikesPhoto.Value.ToString();
                i++;
            }

            likeMeTheLeastChart.Invalidate();

            ((ISupportInitialize)likeMeTheMostChart).EndInit();
            ((ISupportInitialize)likeMeTheLeastChart).EndInit();

            panel.Controls.Add(likeMeTheMostChart, 0, 0);
            panel.Controls.Add(likeMeTheLeastChart, 0, 1);

            return panel;
        }
    }
}
