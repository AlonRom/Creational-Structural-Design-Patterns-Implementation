using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Helpers;
using FacebookVip.Logic.Interfaces;
using FacebookWrapper;
using Unity;

namespace FacebookVip.UI
{

    public partial class DashboardForm : Form
    {
        private ILoginService m_LoginService;

        public DashboardForm()
        {
            InitializeComponent();
            setFormStyle();
            registerEvents();
        }

        private void registerEvents()
        {
            Resize += resizeFormEvent;
        }

        private void setFormStyle()
        {
            TopMost = true;
            setFormSize(); 
            CenterToScreen();
            centerSpinnerInScreen();
            customHeaderLayout();
            spinner.Visible = false;
        }

        private void setFormSize()
        {
            Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6);
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.7);
            customHeaderPictureBox.Width = Screen.GetWorkingArea(this).Width; // make it the same width as the form
        }

        private void resizeFormEvent(object i_Sender, EventArgs i_EventArgs)
        {
            loginLabel.Location = new Point(userImage.Location.X + 55, loginLabel.Location.Y);
        }

        private void centerSpinnerInScreen()
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

            Point loginLabelPosition = PointToScreen(loginLabel.Location);
            loginLabelPosition = customHeaderPictureBox.PointToClient(loginLabelPosition);
            loginLabel.Parent = customHeaderPictureBox;
            loginLabel.Location = loginLabelPosition;
        }

        private async void loginButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                spinner.Visible = true;
 
                m_LoginService = ContainerHelper.Container.Resolve<ILoginService>();
                LoginResult loginResult = m_LoginService.Login();
  
                //Tocken: EAAUm6cZC4eUEBAFvYpV07wRmWXbUUfCw5clPTu7ZBqnuUVFLpezLBEczeelSSaClNkqGDdIgSsnCSMrFJBBnbrQYfdQJDrZBd59c2VZCCUPdyYplFu06cgX0JqIUBr05ElY5zU3FLNZCmsyfbxZByPtMpOIqUJSWv4ZBytRBlQURgZDZD
                if (!string.IsNullOrEmpty(loginResult.AccessToken))
                {
                    m_LoginService.LoggedInUser = loginResult.LoggedInUser;
                    setLayoutVisible();
                    await m_LoginService.SetUserData();

                    userImage.Visible = true;
                    userImage.Image = m_LoginService.LoggedInUser.ImageSmall;
                    loginLabel.Text = @"Logout";
                }
                else
                {
                    MessageBox.Show(loginResult.ErrorMessage);
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                spinner.Visible = false;
            }
        }

        private void setLayoutVisible()
        {
            contentPanel.Visible = true;
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Visible = true;
            }
        }

        private  void profileButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2 };
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int tempRowIndex = 0;
                const int k_PropertyColumnIndex = 0;
                const int k_DetailsColumnIndex = 1;

                foreach (KeyValuePair<string, string> propertyForDisplay in m_LoginService.UserProfile.GetPropertiesForDisplay())
                {
                    panel.Controls.Add(new Label { Font = new Font("Arial", 12, FontStyle.Bold), Text = propertyForDisplay.Key }, k_PropertyColumnIndex, tempRowIndex);
                    panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = propertyForDisplay.Value }, k_DetailsColumnIndex, tempRowIndex);
                    tempRowIndex++;
                }
                panel.Padding = new Padding(10);
                panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(panel);
            }
            catch (Exception)
            {

            }
            finally
            {

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

        protected override void Dispose(bool i_Disposing)
        {
            if (i_Disposing)
            {
                components?.Dispose();
                Resize -= resizeFormEvent;
            }

            base.Dispose(i_Disposing);
        }
    }
}
