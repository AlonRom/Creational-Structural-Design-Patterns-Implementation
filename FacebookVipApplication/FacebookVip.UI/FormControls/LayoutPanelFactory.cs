using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookVip.UI.FormControls
{
    class LayoutPanelFactory
    {
        public enum LayoutPanelType
        {
            CheckinLayoutPanel,
            EventLayoutPanel,
            FriendLayoutPanel,
            LikesLayoutPanel,
            ProfileLayoutPanel,
            SettingsLayoutPanel,
            StatsLayoutPanel,
            PostsLayoutPanel
        }

        public static ILayoutPanel GetLayoutPanel(LayoutPanelType i_LayoutPanelType) {
            
            switch (i_LayoutPanelType) {
                case LayoutPanelType.CheckinLayoutPanel:
                    return new CheckinLayoutPanel();
                case LayoutPanelType.EventLayoutPanel:
                    return new EventLayoutPanel();
                case LayoutPanelType.FriendLayoutPanel:
                    return new FriendLayoutPanel();
                case LayoutPanelType.LikesLayoutPanel:
                    return new LikesLayoutPanel();
                case LayoutPanelType.ProfileLayoutPanel:
                    return new ProfileLayoutPanel();
                case LayoutPanelType.SettingsLayoutPanel:
                    return new SettingsLayoutPanel();
                case LayoutPanelType.StatsLayoutPanel:
                    return new StatsLayoutPanel();
                case LayoutPanelType.PostsLayoutPanel:
                    return new PostLayoutPanel();
                default:
                    return null;
            }
        }
    }
}
