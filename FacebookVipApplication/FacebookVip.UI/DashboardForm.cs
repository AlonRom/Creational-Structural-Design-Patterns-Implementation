using System;
using System.Drawing;
using System.Threading.Tasks;
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
        }

        private void setFormStyle()
        {
            TopMost = true;
            //WindowState = FormWindowState.Maximized;
            Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.7);
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.7);
            CenterToScreen();
            ShowIcon = false;
            Spinner.Visible = false;
        }

        private void setCustomHeader()
        {
            //customHeaderPictureBox.Location = Location; // assign the location to the form location
            customHeaderPictureBox.Width = Screen.GetWorkingArea(this).Width; // make it the same width as the form

        }

        private async void sideMenuListViewSelectedIndexChanged(object i_Sender, System.EventArgs i_EventArgs)
        {
            try
            {
                Spinner.Visible = true;
                await Task.Delay(5000);

            }
            catch(Exception)
            {

            }
            finally
            {
                Spinner.Visible = false;
            }
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
