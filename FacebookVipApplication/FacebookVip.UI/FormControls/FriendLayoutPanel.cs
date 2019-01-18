using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Iterator;
using FacebookVip.Logic.Services;
using FacebookVip.UI.Utils;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    internal class FriendLayoutPanel : ILayoutPanel
    {
        public async Task<TableLayoutPanel> GetLayoutPanelAsync(User i_LoggedInUser)
        {
            UserConcreteAggregate userConcreteAggregate = new UserConcreteAggregate(i_LoggedInUser);
            //this waits for the initialization to finish
            await userConcreteAggregate.Initialization;
            IIterator it = userConcreteAggregate.CreateIterator();
            return GetLayoutPanelAsync(it);
        }

        public TableLayoutPanel GetLayoutPanelAsync(IIterator i_Iterator)
        {
            TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true, Padding = new Padding(10) };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

            int tempRowIndex = 0;
            const int k_ImageColumnIndex = 0;
            const int k_DetailsColumnIndex = 1;

            while (i_Iterator.MoveNext())
            {
                foreach (KeyValuePair<string, string> propertyForDisplay in i_Iterator.Current.GetPropertiesForDisplay())
                {
                    Uri uriResult;
                    bool isImageUrl = Uri.TryCreate(propertyForDisplay.Value, UriKind.Absolute, out uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                    if (isImageUrl)
                    {
                        panel.Controls.Add(new PictureBox { ImageLocation = propertyForDisplay.Value, AutoSize = true }, k_ImageColumnIndex, tempRowIndex);
                    }
                    else
                    {
                        panel.Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, AppConfigService.GetInstance().LabelFontSize), AutoSize = true, Text = propertyForDisplay.Value }, k_DetailsColumnIndex, tempRowIndex);
                    }
                }
                tempRowIndex++;
            }
            return panel;
        }
    }
}
