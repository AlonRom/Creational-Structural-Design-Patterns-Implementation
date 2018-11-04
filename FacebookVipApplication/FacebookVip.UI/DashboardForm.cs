using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        }

        private void setFormStyle()
        {
            TopMost = true;
            resizeForm(); 
            CenterToScreen();
            centerSpinnerInPanel();
            customHeaderLayout();
            spinner.Visible = false;
        }

        private void resizeForm()
        {
            Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6);
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.7);
            customHeaderPictureBox.Width = Screen.GetWorkingArea(this).Width; // make it the same width as the form
        }

        private void centerSpinnerInPanel()
        {
            spinner.Location = new Point(
                                   spinner.Parent.ClientSize.Width/2 - spinner.Width/2,
                                   spinner.Parent.ClientSize.Height/2 - spinner.Height/2);
            spinner.Refresh();
        }


        private void customHeaderLayout()
        {
            ShowIcon = false;

            Point headerFacebookLabelPosition = PointToScreen(headerFacebookLabel.Location);
            headerFacebookLabelPosition = customHeaderPictureBox.PointToClient(headerFacebookLabelPosition);
            headerFacebookLabel.Parent = customHeaderPictureBox;
            headerFacebookLabel.Location = headerFacebookLabelPosition;

            Point headerTitleLabelPosition = PointToScreen(headerTitleLabel.Location);
            headerTitleLabelPosition = customHeaderPictureBox.PointToClient(headerTitleLabelPosition);
            headerTitleLabel.Parent = customHeaderPictureBox;
            headerTitleLabel.Location = headerTitleLabelPosition;

            Point logoInsideOutImagePosition = PointToScreen(logoInsideOutImage.Location);
            logoInsideOutImagePosition = customHeaderPictureBox.PointToClient(logoInsideOutImagePosition);
            logoInsideOutImage.Parent = customHeaderPictureBox;
            logoInsideOutImage.Location = logoInsideOutImagePosition;
        }


        private async void loginButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                spinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

            }
            finally
            {
                spinner.Visible = false;
            }
        }

        private async void friendsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                spinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

            }
            finally
            {
                spinner.Visible = false;
            }
        }

        private async void postsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                spinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

            }
            finally
            {
                spinner.Visible = false;
            }
        }

        private async void eventsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                spinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

            }
            finally
            {
                spinner.Visible = false;
            }
        }

        private async void likesButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                spinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

            }
            finally
            {
                spinner.Visible = false;
            }
        }


        private async void checkinsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                spinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

            }
            finally
            {
                spinner.Visible = false;
            }
        }


        private async void statsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                spinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

            }
            finally
            {
                spinner.Visible = false;
            }
        }


        private async void settingsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                spinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

            }
            finally
            {
                spinner.Visible = false;
            }
        }

    }
}
