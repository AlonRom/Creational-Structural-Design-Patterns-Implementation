using System;
using FacebookVip.Logic.Interfaces;

namespace FacebookVip.UI.FormControls
{
    public class CheckBoxMenuItem : MenuItem
    {
        public ICommandWithParameter Command { get; set; }
        protected override void OnClick(EventArgs i_EventArgs)
        {
            Checked = !Checked;
            Command?.Execute(Checked);
        }
    }
}
