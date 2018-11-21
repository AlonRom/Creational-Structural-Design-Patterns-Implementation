namespace FacebookVip.UI.FormControls
{
    static class LayoutPanelFactory
    {
        public enum eLayoutPanelType
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

        public static ILayoutPanel GetLayoutPanel(eLayoutPanelType i_LayoutPanelType) {
            
            switch (i_LayoutPanelType) {
                case eLayoutPanelType.CheckinLayoutPanel:
                    return new CheckinLayoutPanel();
                case eLayoutPanelType.EventLayoutPanel:
                    return new EventLayoutPanel();
                case eLayoutPanelType.FriendLayoutPanel:
                    return new FriendLayoutPanel();
                case eLayoutPanelType.LikesLayoutPanel:
                    return new LikesLayoutPanel();
                case eLayoutPanelType.ProfileLayoutPanel:
                    return new ProfileLayoutPanel();
                case eLayoutPanelType.SettingsLayoutPanel:
                    return new SettingsLayoutPanel();
                case eLayoutPanelType.StatsLayoutPanel:
                    return new StatsLayoutPanel();
                case eLayoutPanelType.PostsLayoutPanel:
                    return new PostLayoutPanel();
                default:
                    return null;
            }
        }
    }
}
