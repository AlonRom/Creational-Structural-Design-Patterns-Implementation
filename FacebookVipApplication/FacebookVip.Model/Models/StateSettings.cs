using System;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookVip.Model.Enums;
using FacebookVip.Model.Utils;

namespace FacebookVip.Model.Models
{
    public class StateSettings
    {
        public SeriesChartType SelectedChartType { get; set; } = SeriesChartType.Column;

        public int NumberOfFriend { get; set; } = 7;

        public SerializableDictionary<eLikedItem, bool> LikedItems { get; set; }

        public StateSettings()
        {
            LikedItems = new SerializableDictionary<eLikedItem, bool>();
            foreach(eLikedItem likedItem in Enum.GetValues(typeof(eLikedItem)))
            {
                LikedItems.Add(likedItem, true);
            }
        }
    }
}
