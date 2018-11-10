using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;


namespace FacebookVip.UI
{

    public partial class DashboardForm : Form
    {
        private readonly ILoginService r_LoginService;

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
            }
            catch(Exception)
            {

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
            userImage.Image = r_LoginService.LoggedInUser.ImageSmall;
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
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();

                ProfileModel userPorfile = await r_LoginService.GetUserProfile();

                TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2 };
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int tempRowIndex = 0;
                const int k_PropertyColumnIndex = 0;
                const int k_DetailsColumnIndex = 1;

                foreach (KeyValuePair<string, string> propertyForDisplay in userPorfile.GetPropertiesForDisplay())
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
                contentSpinner.Visible = false;
            }
        }

        private async void friendsButtonClickAsync(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();

                List<FriendModel> userFriends = await r_LoginService.GetUserFriends(); 

                TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true};
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int tempRowIndex = 0;
                const int k_ImageColumnIndex = 0;
                const int k_DetailsColumnIndex = 1;

                foreach(FriendModel friend in userFriends)
                {
                    foreach (KeyValuePair<string, string> propertyForDisplay in friend.GetPropertiesForDisplay())
                    {
                        Uri uriResult;
                        bool isImageUrl = Uri.TryCreate(propertyForDisplay.Value, UriKind.Absolute, out uriResult)
                            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                        if(isImageUrl)
                        {
                            panel.Controls.Add(new PictureBox { ImageLocation = propertyForDisplay.Value }, k_ImageColumnIndex, tempRowIndex);
                        }
                        else
                        {
                            panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = propertyForDisplay.Value }, k_DetailsColumnIndex, tempRowIndex);
                        }             
                    }
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
                contentSpinner.Visible = false;
            }
        }

        private async void postsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();

                List<PostModel> userPosts = await r_LoginService.GetUserPosts();

                TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true};
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int tempRowIndex = 0;
                int tempColumnIndex = 0;

                foreach(PostModel post in userPosts)
                {
                    foreach (KeyValuePair<string, string> propertyForDisplay in post.GetPropertiesForDisplay())
                    {
                        panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = propertyForDisplay.Value, AutoSize = true}, tempColumnIndex, tempRowIndex);
                        tempColumnIndex++;
                    }
                    tempColumnIndex = 0;
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
                contentSpinner.Visible = false;
            }
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

            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private async void likesButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;

                #region Get data

                PostedItem p = new Photo();
                ObservableCollection<PostedItem> items;

                items = new ObservableCollection<PostedItem>(r_LoginService.LoggedInUser.PhotosTaggedIn);
                Dictionary<string, int> user_likes_photos = await LikesStatisticsService.getLikesHistogram(items);

                //Mock data
                user_likes_photos.Add("Igor Gumush", 12);
                user_likes_photos.Add("Alon Rom", 32);
                user_likes_photos.Add("Muhamad Ali", 4);
                user_likes_photos.Add("Madona", 7);

                items = new ObservableCollection<PostedItem>(r_LoginService.LoggedInUser.Posts);
                Dictionary<string, int> user_likes_posts = await LikesStatisticsService.getLikesHistogram(items);

                user_likes_posts.Add("Igor Gumush", 12);
                user_likes_posts.Add("Alon Rom", 32);
                user_likes_posts.Add("Muhamad Ali", 4);
                user_likes_posts.Add("Madona", 7);
                user_likes_posts.Add("Shula Mokshim", 4);
                user_likes_posts.Add("Bibi", 4);

                /*
                                items = new ObservableCollection<PostedItem>(m_LoginService.LoggedInUser.Albums);
                                Dictionary<string, int> user_likes_albums = LikesStatisticsService.getLikesHistogram(items);
                */
                #endregion

                resetContentPanel();

                TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true };
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                Font label_font = new Font("Arial", 12);
                Font title_font = new Font("Arial", 20);

                int tempRowIndex = 0;
                int tempColumnIndex = 0;

                fillLikeToTable("Photos", user_likes_photos, panel, label_font, title_font, ref tempRowIndex, ref tempColumnIndex);
                fillLikeToTable("Posts", user_likes_posts, panel, label_font, title_font, ref tempRowIndex, ref tempColumnIndex);

                panel.Padding = new Padding(10);
                panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(panel);

                //await Task.Delay(5000);

            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private void fillLikeToTable(string i_LableName, Dictionary<string, int> i_UserLikesPhotos, TableLayoutPanel i_Panel, Font i_LabelFont, Font i_TitleFont, ref int r_TempRowIndex, ref int r_TempColumnIndex)
        {
            i_Panel.Controls.Add(new Label { Font = i_TitleFont, Text = i_LableName, AutoSize = true }, r_TempColumnIndex, r_TempRowIndex++);
            foreach (KeyValuePair<string, int> propertyForDisplay in i_UserLikesPhotos)
            {
                i_Panel.Controls.Add(new Label { Font = i_LabelFont, Text = propertyForDisplay.Key, AutoSize = true }, r_TempColumnIndex++, r_TempRowIndex);
                i_Panel.Controls.Add(new Label { Font = i_LabelFont, Text = "" + propertyForDisplay.Value, AutoSize = true }, r_TempColumnIndex, r_TempRowIndex);
                r_TempColumnIndex = 0;
                r_TempRowIndex++;
            }
            r_TempRowIndex += 2;
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

            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }


        private async void statsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }


        private async void settingsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {

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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            AppConfigService appConfig = AppConfigService.GetInstance();
            appConfig.WindowPosition = new Point(this.Top, this.Left);
            // TODO: add check box stay logged in
            //appConfig.LastAccessTocken = "";

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
    }
}
