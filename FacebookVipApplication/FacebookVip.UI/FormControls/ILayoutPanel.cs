using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    public interface ILayoutPanel
    {
        Task<TableLayoutPanel> GetLayoutPanelAsync(User i_LoggedInUser);
    }
}