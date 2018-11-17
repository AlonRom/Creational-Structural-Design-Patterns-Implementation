using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI.FormControls
{
    public interface ILayoutPanel
    {
        Task<TableLayoutPanel> GetLayoutAsync(User i_LoggedInUser);
    }
}