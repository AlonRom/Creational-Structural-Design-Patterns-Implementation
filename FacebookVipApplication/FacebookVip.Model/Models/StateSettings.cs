using System;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookVip.Model.Enums;
using FacebookVip.Model.Utils;

namespace FacebookVip.Model.Models
{
    public class StateSettings
    {
        public SeriesChartType SelectedChartType { get; set; }

        public int NumberOfFriend { get; set; } = 10;

        public SerializableDictionary<eLikedItem, bool> LikedItems { get; set; }

        public StateSettings()
        {
            LikedItems = new SerializableDictionary<eLikedItem, bool>();
            foreach(eLikedItem likedItem in Enum.GetValues(typeof(eLikedItem)))
            {
                LikedItems.Add(likedItem, false);
            }
        }
    }
}
