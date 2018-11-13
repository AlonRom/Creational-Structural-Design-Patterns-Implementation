using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.Drawing;
using FacebookVip.Logic.Extensions;
using System.Collections.Generic;

namespace FacebookVip.Model
{
    public class PostControl : TableLayoutPanel
    {
        private Font TextFont{ get; set; }

        public PostControl(PostModel post, int i_ColumnIdx = 0, int i_RowIdx = 0) {
            AutoSize = true;
            ColumnCount = 2; // Num of prop for display
            //ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            //ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
            //RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

            

            Margin = new Padding(0, 0, 0, 0);

            TextFont =  new Font("Arial", 12);

            foreach (KeyValuePair<string, string> propertyForDisplay in post.GetPropertiesForDisplay())
            {
                Controls.Add(new Label { Font = new Font("Arial", 12), Text = propertyForDisplay.Value, AutoSize = true }, i_ColumnIdx, i_RowIdx);
                i_ColumnIdx++;
            }
        }

    }
}
