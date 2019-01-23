using System;
using System.Windows.Forms;
using FacebookVip.Logic.Interfaces;

namespace FacebookVip.UI.FormControls
{

    public class MenuItem : ToolStripMenuItem
    {
        public ICommand Command { get; set; }
        protected override void OnClick(EventArgs i_EventArgs)
        {
            Command?.Execute();
        }
    }
}
