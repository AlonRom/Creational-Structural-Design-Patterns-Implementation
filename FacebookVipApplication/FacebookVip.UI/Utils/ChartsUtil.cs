using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;

namespace FacebookVip.UI.Utils
{
    public static class ChartsUtil
    {
        public static Chart CreateChart(string i_ChartTitle, DockStyle i_DockStyle, IEnumerable<KeyValuePair<string, int>> i_DataCollection)
        {
            StateSettings appConfigServiceStateSettings = AppConfigService.GetInstance().StateSettings;
            Chart chart = new Chart();
            ((ISupportInitialize)chart).BeginInit();
            ChartArea chartsArea = new ChartArea();
            chart.ChartAreas.Add(chartsArea);
            chart.Dock = i_DockStyle;

            if (appConfigServiceStateSettings.SelectedChartType == SeriesChartType.Pie)
            {
                Legend legend = new Legend { BackColor = Color.White, ForeColor = Color.Black };
                chart.Legends.Add(legend);
            }

            Title title = chart.Titles.Add(i_ChartTitle);
            title.Font = new Font(AppUtil.sr_FontFamily, 16, FontStyle.Bold);
            title.Alignment = ContentAlignment.TopCenter;

            chart.Series.Clear();
            chart.ChartAreas[0].BackColor = Color.Transparent;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Series series = new Series
            {
                IsVisibleInLegend = true,
                ChartType = appConfigServiceStateSettings.SelectedChartType
            };
            chart.Series.Add(series);


            int i = 0;
            Random rnd = new Random();
            foreach (KeyValuePair<string, int> userLikesPhoto in i_DataCollection)
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

            chart.Invalidate();
            ((ISupportInitialize)chart).EndInit();
            return chart;
        }
    }
}
