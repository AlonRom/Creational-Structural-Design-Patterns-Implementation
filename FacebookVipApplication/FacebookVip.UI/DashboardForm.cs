using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Adapters;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookVip.UI.FormControls;
using FacebookVip.UI.Properties;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using static FacebookVip.UI.FormControls.LayoutPanelFactory;
using ICommand = FacebookVip.Logic.Interfaces.ICommand;
using MenuItem = FacebookVip.UI.FormControls.MenuItem;

namespace FacebookVip.UI
{

    public partial class DashboardForm : Form
    {
        private readonly ILoginService r_LoginService;

        private TableLayoutPanel m_Panel;
        private ContextMenuStrip m_ContextMenuStrip;

        public DashboardForm()
        {
            InitializeComponent();
            setFormStyle();
            registerEvents();

            r_LoginService = LoginService.GetInstance();

            initMenu();
        }

        private void initMenu()
        {
            menu.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);//transparent
            m_ContextMenuStrip = new ContextMenuStrip();

            m_ContextMenuStrip.Items.Add(new MenuItem { Text = Resources.DashboardForm_initMenu_Clear_Dashboard, Command = new ClearDashboardCommand { Client = this } });
            m_ContextMenuStrip.Items.Add(new MenuItem { Text = Resources.DashboardForm_initMenu_Change_Theme, Command = new ChangeThemeCommand { Client = this } });
            m_ContextMenuStrip.Items.Add(new CheckBoxMenuItem { Text = Resources.DashboardForm_initMenu_Stay_Logged_In, Command = new StayLoggedInCommand { Client = this } });
            m_ContextMenuStrip.Items.Add(new MenuItem { Text = Resources.DashboardForm_initMenu_Settings, Command = new ShowSettingsCommand { Client = this } });
            m_ContextMenuStrip.Items.Add(new MenuItem { Text = Resources.DashboardForm_initMenu_Logout, Command = new LogoutCommand { Client = this } });
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
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);
            customHeaderPictureBox.Width = Screen.GetWorkingArea(this).Width; // make it the same width as the form
        }

        private void resizeFormEvent(object i_Sender, EventArgs i_EventArgs)
        {
            loginLabel.Location = new Point(userImage.Location.X + 50, loginLabel.Location.Y);
            menu.Location = new Point(loginLabel.Location.X + 30, loginLabel.Location.Y);
        }

        private void centerControlInParent(Control i_Control)
        {
            i_Control.Location = new Point(
                contentPanel.Width / 2 - i_Control.Width / 2,
                contentPanel.Height / 2 - i_Control.Height / 2
            );
            i_Control.BringToFront();
            i_Control.Refresh();
        }

        private void customHeaderLayout()
        {
            Icon = Resources.app_logo;

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

            Point loginSpinnerPosition = PointToScreen(loginSpinner.Location);
            loginSpinnerPosition = customHeaderPictureBox.PointToClient(loginSpinnerPosition);
            loginSpinner.Parent = customHeaderPictureBox;
            loginSpinner.Location = loginSpinnerPosition;

            Point menuPosition = PointToScreen(menu.Location);
            menuPosition = customHeaderPictureBox.PointToClient(menuPosition);
            menu.Parent = customHeaderPictureBox;
            menu.Location = menuPosition;
            menu.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void resetContentPanel()
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(contentSpinner);
            centerControlInParent(contentSpinner);
        }

        private void logoutButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            logout();
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
                MessageBox.Show(Resources.LoginErrorMessage, Resources.LoginErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //loginLabel.Text = Resources.LogoutButton;
            loginLabel.Visible = false;
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
            await updatePanelAsync(eLayoutPanelType.ProfileLayoutPanel);
        }

        private async void friendsButtonClickAsync(object i_Sender, EventArgs i_EventArgs)
        {
            await updatePanelAsync(eLayoutPanelType.FriendLayoutPanel);
        }

        private async void postsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            await updatePanelAsync(eLayoutPanelType.PostsLayoutPanel);
        }

        private async void eventsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            await updatePanelAsync(eLayoutPanelType.EventLayoutPanel);
        }

        private async void likesButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            await updatePanelAsync(eLayoutPanelType.LikesLayoutPanel);
        }

        private async void checkinsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            await updatePanelAsync(eLayoutPanelType.CheckinLayoutPanel);
        }

        private async void statsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            await updatePanelAsync(eLayoutPanelType.StatsLayoutPanel);
        }

        private async Task updatePanelAsync(eLayoutPanelType i_LayoutType)
        {
            contentSpinner.Visible = true;
            resetContentPanel();
            ILayoutPanel layout = LayoutPanelFactory.CreateLayout(i_LayoutType);
            try
            {
                m_Panel = await layout.GetLayoutPanelAsync(r_LoginService.LoggedInUser);
                m_Panel.Padding = new Padding(10);
                m_Panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(m_Panel);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.RetriveDataErrorMessage, Resources.RetriveDataErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        protected override void OnShown(EventArgs i_EventArgs)
        {
            base.OnShown(i_EventArgs);

            AppConfigService appConfig = AppConfigService.GetInstance();
            Top = appConfig.WindowPosition.X;
            Left = appConfig.WindowPosition.Y;
            Height = appConfig.WindowHeight;
            Width = appConfig.WindowWidth;

            try
            {
                if (!string.IsNullOrEmpty(appConfig.LastAccessTocken))
                {
                    LoginResult loginParams = FacebookService.Connect(appConfig.LastAccessTocken);
                    if (loginParams != null)
                    {
                        r_LoginService.LoggedInUser = loginParams.LoggedInUser;
                        postLogin();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.ConnectWithTokenErrorMessage, Resources.FacebookConnectionErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected override void OnClosing(CancelEventArgs i_EventArgs)
        {
            base.OnClosing(i_EventArgs);
            AppConfigService appConfig = AppConfigService.GetInstance();
            appConfig.WindowPosition = new Point(this.Top, this.Left);
            appConfig.WindowWidth = this.Width;
            appConfig.WindowHeight = this.Height;
            AppConfigService.SaveToFile();
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

        private void dataBindingFriendsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            contentSpinner.Visible = true;
            resetContentPanel();

            try
            {
                friendsDataBindingContentPanel.Visible = true;

                friendsDataBindingContentPanel.Padding = new Padding(10);
                friendsDataBindingContentPanel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(friendsDataBindingContentPanel);

                new Thread(() =>
                {
                    //time consuming operation
                    IFriendService friendService = new FriendService();
                    FacebookObjectCollection<User> userFriends = friendService.GetUserFriends(r_LoginService.LoggedInUser);

                    //invoke the UI
                    if (!friendsListBox.InvokeRequired)
                    {
                        //binding the data source of the binding source, to our data source
                        userBindingSource.DataSource = userFriends;
                        contentSpinner.Visible = false;
                    }
                    else
                    {
                        // In case of cross-thread operation, invoking the binding code on the listBox's thread
                        friendsListBox.Invoke(new Action(() => userBindingSource.DataSource = userFriends));
                        contentSpinner.Invoke(new Action(() => contentSpinner.Visible = false));
                    }

                }).Start();
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.RetriveDataErrorMessage, Resources.RetriveDataErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void adapterFriendsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            contentSpinner.Visible = true;
            resetContentPanel();
            FriendLayoutPanel layout = (FriendLayoutPanel)LayoutPanelFactory.CreateLayout(eLayoutPanelType.FriendLayoutPanel);
            try
            {
                IFriendsAdapter friendsAdapter = new FriendsAdapter();
                List<FriendModel> userFriends = await friendsAdapter.GetUserFriendsAsync();

                //m_Panel = layout.GetLayoutPanelAsync(userFriends);
                //m_Panel.Padding = new Padding(10);
                //m_Panel.Dock = DockStyle.Fill;
                //contentPanel.Controls.Add(m_Panel);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.RetriveDataErrorMessage, Resources.RetriveDataErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private void menuClick(object i_Sender, EventArgs i_EventArgs)
        {
            m_ContextMenuStrip.Show(menu, new Point(-130, menu.Height));
        }

        #region Command Operations
        private void clearDahsboard()
        {
            resetContentPanel();
        }

        private void changeTheme()
        {
            contentPanel.BackColor = contentPanel.BackColor == Color.White ? Color.LightSkyBlue : Color.White;
        }

        private void stayLoggedIn(bool i_Checked)
        {
            AppConfigService appConfig = AppConfigService.GetInstance();
            appConfig.StayLogedIn = i_Checked;
        }

        private async void showSettings()
        {
            await updatePanelAsync(eLayoutPanelType.SettingsLayoutPanel);
        }

        private void logout()
        {
            try
            {
                loginLabel.Enabled = false;
                loginSpinner.Visible = true;

                r_LoginService.Logout();
                loginLabel.Click -= logoutButtonClick;
                loginLabel.Click += loginButtonClick;
                loginLabel.Text = Resources.LoginButton;
                setLayoutVisible(false);
                r_LoginService.LoggedInUser = null;

                AppConfigService appConfig = AppConfigService.GetInstance();
                appConfig.LastAccessTocken = "";
                loginLabel.Visible = true;
            }
            finally
            {
                loginLabel.Enabled = true;
                loginSpinner.Visible = false;
            }
        }

        #endregion

        #region Menu Commands

            #region Clear Dashboard Command
            private class ClearDashboardCommand : ICommand
            {
                public DashboardForm Client { get; set; }

                public void Execute()
                {
                    Client.clearDahsboard();
                }
            }

            #endregion

            #region Change Theme Command
            private class ChangeThemeCommand : ICommand
            {
                public DashboardForm Client { get; set; }

                public void Execute()
                {
                    Client.changeTheme();
                }
            }

            #endregion

            #region Stay Logged In Command
            private class StayLoggedInCommand : ICommandWithParameter
            {
                    public DashboardForm Client { get; set; }


                public void Execute(bool i_Checked)
                {
                    Client.stayLoggedIn(i_Checked);
                }
            }

            #endregion

            #region Show Settings Command

            private class ShowSettingsCommand : ICommand
            {
                public DashboardForm Client { get; set; }

                public void Execute()
                {
                    Client.showSettings();
                }
            }

            #endregion

            #region Logout Command

            private class LogoutCommand : ICommand
            {
                public DashboardForm Client { get; set; }

                public void Execute()
                {
                    Client.logout();
                }
            }

            #endregion

        #endregion
    }
}
