using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Helpers;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Model;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
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
            m_LoginService.Logout();
            loginLabel.Click -= logoutButtonClick;
            loginLabel.Click += loginButtonClick;
            loginLabel.Text = @"Login";
            setLayoutVisible(false);
            m_LoginService.LoggedInUser = null;
        }

        private void loginButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                loginSpinner.Visible = true;
 
                m_LoginService = ContainerHelper.Container.Resolve<ILoginService>();
                LoginResult loginResult = m_LoginService.Login();
  
                //Tocken: EAAUm6cZC4eUEBAFvYpV07wRmWXbUUfCw5clPTu7ZBqnuUVFLpezLBEczeelSSaClNkqGDdIgSsnCSMrFJBBnbrQYfdQJDrZBd59c2VZCCUPdyYplFu06cgX0JqIUBr05ElY5zU3FLNZCmsyfbxZByPtMpOIqUJSWv4ZBytRBlQURgZDZD
                if (!string.IsNullOrEmpty(loginResult.AccessToken))
                {
                    m_LoginService.LoggedInUser = loginResult.LoggedInUser;
                    setLayoutVisible(true);

                    userImage.Visible = true;
                    userImage.Image = m_LoginService.LoggedInUser.ImageSmall;
                    loginLabel.Text = @"Logout";
                    loginLabel.Click -= loginButtonClick;
                    loginLabel.Click += logoutButtonClick;
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
                loginSpinner.Visible = false;
            }
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

                UserProfile userPorfile = await m_LoginService.GetUserProfile();

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

                List<UserFriend> userFriends = await m_LoginService.GetUserFriends(); 

                TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true};
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int tempRowIndex = 0;
                const int k_ImageColumnIndex = 0;
                const int k_DetailsColumnIndex = 1;

                foreach(UserFriend friend in userFriends)
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

                List<UserPost> userPosts = await m_LoginService.GetUserPosts();

                TableLayoutPanel panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true};
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int tempRowIndex = 0;
                int tempColumnIndex = 0;

                foreach(UserPost post in userPosts)
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


        private Dictionary<string, int> getLikesHistogram(ObservableCollection<PostedItem> items) {

            var users_likes_histogram = new Dictionary<string, int>();

            foreach (var item in items)
            {
                var likes = item.LikedBy;
                foreach (var like in likes)
                {
                    string friend_name = like.Name;
                    if (friend_name == null) continue;
                    if (!users_likes_histogram.ContainsKey(friend_name))
                    {
                        users_likes_histogram[friend_name] = 0;
                    }
                    users_likes_histogram[friend_name] += 1;
                }
            }
            return users_likes_histogram;
        }

        private async void likesButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;

                PostedItem p = new Photo();
                ObservableCollection<PostedItem> items;

                items = new ObservableCollection<PostedItem>(m_LoginService.LoggedInUser.PhotosTaggedIn);
                Dictionary<string, int> user_likes_photos = getLikesHistogram(items);

                items = new ObservableCollection<PostedItem>(m_LoginService.LoggedInUser.Posts);
                Dictionary<string, int> user_likes_posts = getLikesHistogram(items);

                items = new ObservableCollection<PostedItem>(m_LoginService.LoggedInUser.Albums);
                Dictionary<string, int> user_likes_albums = getLikesHistogram(items);


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
