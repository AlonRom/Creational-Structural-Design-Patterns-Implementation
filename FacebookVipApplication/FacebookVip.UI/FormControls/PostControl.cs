﻿using FacebookVip.Logic.Extensions;
using FacebookVip.Model.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookVip.Logic.Services;
using FacebookVip.UI.Utils;

namespace FacebookVip.UI.FormControls
{
    public class PostControl : TableLayoutPanel
    {

        public PostControl(PostModel i_Post, int i_ColumnIdx = 0, int i_RowIdx = 0)
        {
            Name = i_Post.UserName;
            
            AutoSize = true;
            ColumnCount = 2; // Num of prop for display           
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));

            Padding = new Padding(10, 10, 10, 10);
            Margin = new Padding(10, 10, 10, 0);

            PictureBox picBox = new PictureBox { Image = i_Post.UserImg };
            Controls.Add(picBox, i_ColumnIdx++, i_RowIdx);
            foreach (KeyValuePair<string, string> propertyForDisplay in i_Post.GetPropertiesForDisplay())
            {
                Controls.Add(new Label { Font = new Font(AppUtil.sr_FontFamily, AppConfigService.GetInstance().LabelFontSize), Text = propertyForDisplay.Value, AutoSize = true }, i_ColumnIdx, i_RowIdx);
                i_ColumnIdx++;
            }
        }
    }
}
