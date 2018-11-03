using System.Windows.Forms;

namespace FacebookVip.UI
{

    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            setFormStyle();
            setCustomHeader();


            SIdeMenuPanel.Controls.Add(new Label{ Text =  "2324324322222222222"});
        }

        private void setFormStyle()
        {
            TopMost = true;
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            ShowIcon = false;
            
        }

        private void setCustomHeader()
        {
            customHeaderPictureBox.Location = Location; // assign the location to the form location
            customHeaderPictureBox.Width = Screen.GetWorkingArea(this).Width; // make it the same width as the form

        }

        //private string getImagePathByName(string i_ImageName)
        //{
        //    string baseDirectory =
        //        Path.GetDirectoryName(
        //            Path.GetDirectoryName(
        //                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
  
        //    return baseDirectory + @"\Resources\Icons\" + i_ImageName; 
        //}
    }
}
