using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using FacebookVip.UI.Utils;
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

            Chart likeMeTheMostChart = ChartsUtil.CreateChart("Who Likes me the most!", DockStyle.Top, 
                                                                allPostemItemsLikes.OrderByDescending(i_L => i_L.Value).
                                                                Take(appConfigServiceStateSettings.NumberOfFriend));
            Chart likeMeTheLeastChart = ChartsUtil.CreateChart("Who Likes me the least!", DockStyle.Bottom, 
                                                                allPostemItemsLikes.OrderBy(i_L => i_L.Value).
                                                                Take(appConfigServiceStateSettings.NumberOfFriend));

            panel.Controls.Add(likeMeTheMostChart, 0, 0);
            panel.Controls.Add(likeMeTheLeastChart, 0, 1);

            return panel;
        }
    }
}
