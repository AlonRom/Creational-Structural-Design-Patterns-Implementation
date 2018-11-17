using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Enums;
using FacebookVip.Model.Models;
using FacebookVip.UI.FormControls;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI
{

    public partial class DashboardForm : Form
    {
        private readonly ILoginService r_LoginService;

        TableLayoutPanel m_Panel;

        public DashboardForm()
        {
            InitializeComponent();
            setFormStyle();
            registerEvents();

            r_LoginService = LoginService.GetInstance();
        }

        private void registerEvents()
        {
            Resize += resizeFormEvent;
        }

        private void setFormStyle()
        {
            setFormSize(); 
            CenterToScreen();
            customHeaderLayout();
            loginSpinner.Visible = false;
            contentSpinner.Visible = false;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void setFormSize()
        {
            Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6);
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.7);
            customHeaderPictureBox.Width = Screen.GetWorkingArea(this).Width; // make it the same width as the form
        }

        private void resizeFormEvent(object i_Sender, EventArgs i_EventArgs)
        {
            loginLabel.Location = new Point(userImage.Location.X + 50, loginLabel.Location.Y);
        }

        private void centerControlInParent(Control i_Control)
        {
            i_Control.Location = new Point(
                                   i_Control.Parent.ClientSize.Width/2 - i_Control.Width/2,
                                   i_Control.Parent.ClientSize.Height/2 - i_Control.Height/2);

            i_Control.BringToFront();
            i_Control.Refresh();
        }

        private void customHeaderLayout()
        {
            Icon = Properties.Resources.app_logo;

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

            Point stayLoggedInLabelPosition = PointToScreen(StayLoggedInLabel.Location);
            stayLoggedInLabelPosition = customHeaderPictureBox.PointToClient(stayLoggedInLabelPosition);
            StayLoggedInLabel.Parent = customHeaderPictureBox;
            StayLoggedInLabel.Location = stayLoggedInLabelPosition;

            Point loginSpinnerPosition = PointToScreen(loginSpinner.Location);
            loginSpinnerPosition = customHeaderPictureBox.PointToClient(loginSpinnerPosition);
            loginSpinner.Parent = customHeaderPictureBox;
            loginSpinner.Location = loginSpinnerPosition;
        }

        private void resetContentPanel()
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(contentSpinner);
            centerControlInParent(contentSpinner);
        }

        private void logoutButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                loginLabel.Enabled = false;
                loginSpinner.Visible = true;

                r_LoginService.Logout();
                loginLabel.Click -= logoutButtonClick;
                loginLabel.Click += loginButtonClick;
                loginLabel.Text = @"Login";
                setLayoutVisible(false);
                r_LoginService.LoggedInUser = null;

                AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
                appAppConfig.LastAccessTocken = "";
            }
            finally
            {
                loginLabel.Enabled = true;
                loginSpinner.Visible = false;
            }
        }

        private void loginButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                loginLabel.Enabled = false;
                loginSpinner.Visible = true;

                LoginResult loginResult = r_LoginService.Login();
  
                //Tocken: EAAUm6cZC4eUEBAFvYpV07wRmWXbUUfCw5clPTu7ZBqnuUVFLpezLBEczeelSSaClNkqGDdIgSsnCSMrFJBBnbrQYfdQJDrZBd59c2VZCCUPdyYplFu06cgX0JqIUBr05ElY5zU3FLNZCmsyfbxZByPtMpOIqUJSWv4ZBytRBlQURgZDZD
                if (!string.IsNullOrEmpty(loginResult.AccessToken))
                {
                    r_LoginService.LoggedInUser = loginResult.LoggedInUser;

                    postLogin();
                }
                else
                {
                    MessageBox.Show(loginResult.ErrorMessage);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to login, please try again.", @"Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loginLabel.Enabled = true;
                loginSpinner.Visible = false;
            }
        }

        private void postLogin()
        {
            setLayoutVisible(true);
            userImage.Visible = true;
            userImage.Image = r_LoginService?.LoggedInUser?.ImageSmall;
            loginLabel.Text = @"Logout";
            loginLabel.Click -= loginButtonClick;
            loginLabel.Click += logoutButtonClick;
        }

        private void setLayoutVisible(bool i_Visible)
        {
            contentPanel.Visible = i_Visible;
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Visible = i_Visible;
            }
            userImage.Visible = i_Visible;
        }

        private async void profileButtonClickAsync(object i_Sender, EventArgs i_EventArgs)
        {
            updatePanelAsync(new ProfileLayoutPanel());
        }

        private async void friendsButtonClickAsync(object i_Sender, EventArgs i_EventArgs)
        {
            updatePanelAsync(new FriendLayoutPanel());
        }

        private async void updatePanelAsync(ILayoutPanel layoutPanel) {
            contentSpinner.Visible = true;
            resetContentPanel();
            try
            {
                m_Panel = await layoutPanel.GetLayoutAsync(r_LoginService.LoggedInUser);
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
            m_Panel.Padding = new Padding(10);
            m_Panel.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(m_Panel);
        }

        private void postsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            updatePanelAsync(new PostLayoutPanel());
        }
        
        private async void eventsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private async void likesButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            updatePanelAsync(new LikesLayoutPanel());
        }

        private async void checkinsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private async void statsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            //AutoScaleDimensions = new SizeF(6F, 13F);
            //AutoScaleMode = AutoScaleMode.Font;

            updatePanelAsync(new StatsLayoutPanel());
        }

        private void settingsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            updatePanelAsync(new SettingsLayoutPanel());
        }

        protected override void OnShown(EventArgs i_EventArgs)
        {
            base.OnShown(i_EventArgs);

            AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
            Top = appAppConfig.WindowPosition.X;
            Left = appAppConfig.WindowPosition.Y;
  
            try
            {
                if(!string.IsNullOrEmpty(appAppConfig.LastAccessTocken))
                {
                    LoginResult loginParams = FacebookService.Connect(appAppConfig.LastAccessTocken);
                    if(loginParams != null)
                    {
                        r_LoginService.LoggedInUser = loginParams.LoggedInUser;
                        postLogin();
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show(@"Failed to connect with currnt Token, please try again.", @"Facebook Connect Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void stayLogedInCheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
            appAppConfig.StayLogedIn = StayLoggedInLabel.Checked;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs i_EventArgs)
        {
            base.OnClosing(i_EventArgs);
            AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
            appAppConfig.WindowPosition = new Point(this.Top, this.Left);

            AppAppConfigService.SaveToFile();
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
