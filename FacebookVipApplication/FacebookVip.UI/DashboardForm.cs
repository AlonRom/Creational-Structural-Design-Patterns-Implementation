using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
        //private Chart _pieChart;
        TableLayoutPanel panel;



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
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();

                IProfileService profileService = new ProfileService(r_LoginService);
                ProfileModel userPorfile = await profileService.GetUserProfileAsync();

                panel = new TableLayoutPanel { ColumnCount = 2 };
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
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                IFriendService friendService = new FriendService(r_LoginService);
                List<FriendModel> userFriends = await friendService.GetUserFriendsAsync(); 

                panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true};
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
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                panel = new TableLayoutPanel { ColumnCount = 1, AutoScroll = true, AutoSize = true };

                IPostService postService = new PostService();
                List<PostModel> userPosts = await postService.GetUserPostsAsync(r_LoginService.LoggedInUser);
                
                int tempRowIndex = 0;

                #region test list
                listBox1.SelectionMode = SelectionMode.MultiExtended;
                listBox1.Width = 150;
                listBox1.Margin = new Padding(50, 20, 20, 20);

                foreach (var user in r_LoginService.LoggedInUser.Friends) {
                    //var posts = user.Posts;
                    listBox1.Items.Add(user);
                }
                panel.Controls.Add(listBox1);
                listBox1.SelectedIndexChanged += PersonSelectedAsync;
                #endregion 

                #region UserPosts
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                panel.Padding = new Padding(20, 0, 20, 0);
                foreach (PostModel post in userPosts)
                {
                    panel.Controls.Add(new PostControl(post, 0 , tempRowIndex));
                    
                    tempRowIndex++;
                }
                #endregion 

                panel.Padding = new Padding(10);
                panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(panel);
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
        
        private async void PersonSelectedAsync(object sender, EventArgs e)
        {

            var postService = new PostService();
            foreach (User user in listBox1.SelectedItems) {
                List<PostModel> userPosts = await postService.GetUserPostsAsync(user);

                foreach (PostModel post in userPosts)
                {
                    panel.Controls.Add(new PostControl(post));
                }    
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
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                resetContentPanel();

                ILikeService likeService = new LikesService();
                ObservableCollection<PostedItem> items = new ObservableCollection<PostedItem>(r_LoginService.LoggedInUser.PhotosTaggedIn);
                Dictionary<string, int> userLikesPhotos = await likeService.GetLikesHistogram(items);

                items = new ObservableCollection<PostedItem>(r_LoginService.LoggedInUser.Posts);
                Dictionary<string, int> userLikesPosts = await likeService.GetLikesHistogram(items);

                items = new ObservableCollection<PostedItem>(r_LoginService.LoggedInUser.Albums);
                Dictionary<string, int> userLikesAlbums = await likeService.GetLikesHistogram(items);

                panel = new TableLayoutPanel { ColumnCount = 3, AutoScroll = true };
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 40F));

                Font labelFont = new Font("Arial", 12);
                Font titleFont = new Font("Arial", 20);

                fillLikeToTable("Photos", userLikesPhotos, panel, labelFont, titleFont, 0, 0);
                fillLikeToTable("Posts", userLikesPosts, panel, labelFont, titleFont, 0, 1);
                fillLikeToTable("Albums", userLikesAlbums, panel, labelFont, titleFont, 0, 2);

                panel.Padding = new Padding(10);
                panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(panel);
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

        private void fillLikeToTable(string i_LableName, Dictionary<string, int> i_UserLikesPhotos, TableLayoutPanel i_Panel, Font i_LabelFont, Font i_TitleFont,  int i_RowIndex, int i_ColumnIndex)
        {
            i_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 50F));
            i_Panel.Controls.Add(new Label { Font = i_TitleFont, Text = i_LableName, AutoSize = true }, i_ColumnIndex, i_RowIndex);
            foreach (KeyValuePair<string, int> propertyForDisplay in i_UserLikesPhotos)
            {
                i_RowIndex++;
                i_Panel.Controls.Add(new Label { Font = i_LabelFont, Text = propertyForDisplay.Key + @" " + propertyForDisplay.Value, AutoSize = true }, i_ColumnIndex, i_RowIndex);
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
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                resetContentPanel();

                ChartArea chartArea1 = new ChartArea();
                Legend legend1 = new Legend()
                { BackColor = Color.Green, ForeColor = Color.Black, Title = "Salary" };
                Legend legend2 = new Legend()
                { BackColor = Color.Green, ForeColor = Color.Black, Title = "Salary" };
                var _pieChart = new Chart();
                var barChart = new Chart();

                ((ISupportInitialize)(_pieChart)).BeginInit();
                ((ISupportInitialize)(barChart)).BeginInit();

                SuspendLayout();

                //===Pie chart
                chartArea1.Name = "PieChartArea";
                _pieChart.ChartAreas.Add(chartArea1);
                _pieChart.Dock = System.Windows.Forms.DockStyle.Fill;
                legend1.Name = "Legend1";
                _pieChart.Legends.Add(legend1);
                _pieChart.Location = new System.Drawing.Point(0, 50);

                _pieChart.Series.Clear();
                _pieChart.Palette = ChartColorPalette.Fire;
                _pieChart.BackColor = Color.LightYellow;
                _pieChart.Titles.Add("Employee Salary");
                _pieChart.ChartAreas[0].BackColor = Color.Transparent;
                Series series1 = new Series
                {
                    Name = "series1",
                    IsVisibleInLegend = true,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Pie
                };
                _pieChart.Series.Add(series1);
                series1.Points.Add(70000);
                series1.Points.Add(30000);
                var p1 = series1.Points[0];
                p1.AxisLabel = "70000";
                p1.LegendText = "Hiren Khirsaria";
                var p2 = series1.Points[1];
                p2.AxisLabel = "30000";
                p2.LegendText = "ABC XYZ";
                _pieChart.Invalidate();

                IPostService postService = new PostService();
                List<PostModel> userPosts = await postService.GetUserPostsAsync(r_LoginService.LoggedInUser);

                contentPanel.Controls.Add(_pieChart);
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

        private async void settingsButtonClick(object i_Sender, EventArgs i_EventArgs)
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

        protected override void OnShown(EventArgs i_EventArgs)
        {
            base.OnShown(i_EventArgs);

            AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
            this.Top = appAppConfig.WindowPosition.X;
            this.Left = appAppConfig.WindowPosition.Y;

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

        private void stayLogedInCheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
            appAppConfig.StayLogedIn = StayLoggedInLabel.Checked;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
